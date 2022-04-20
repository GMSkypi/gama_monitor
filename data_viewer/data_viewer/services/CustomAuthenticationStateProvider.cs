using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace data_viewer.services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private ConfigurationService _config;
    private bool IsLogedIn = false;
    
    public CustomAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage, ConfigurationService config )
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _config = config;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var savedToken = await _localStorage.GetItemAsync<string>("authToken");
        
        if (string.IsNullOrWhiteSpace(savedToken))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        Console.WriteLine("Token present");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
        var response = await _httpClient.GetAsync(
            _config.hostName + "/privatecontent");
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Not authenticated");
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        Console.WriteLine("Authenticated");
       
        //ParseClaimsFromJwt(savedToken), "jwt"
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(savedToken)));
    }

    public void MarkUserAsAuthenticated(string uname)
    {
        //IsLogedIn = true;
        //KeepSession();
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, uname) }, "apiauth"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void MarkUserAsLoggedOut()
    {
        IsLogedIn = false;
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        Console.WriteLine("1");
        var payload = jwt.Split('.')[1];
        Console.WriteLine("2");
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

        if (roles != null)
        {
            if (roles.ToString().Trim().StartsWith("["))
            {
                var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                foreach (var parsedRole in parsedRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
            }

            keyValuePairs.Remove(ClaimTypes.Role);
        }

        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

        return claims;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
    private async void KeepSession()
    {
        while(IsLogedIn)
        {
            var response = await _httpClient.GetAsync(
                _config.hostName + "/oauth/token");
            if (!response.IsSuccessStatusCode)
            {
                MarkUserAsLoggedOut();
            }
            await Task.Delay(10000);
        }
    }
}
}
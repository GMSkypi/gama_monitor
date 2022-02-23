using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Blazored.LocalStorage;
using data_viewer.Model;
using Microsoft.AspNetCore.Components.Authorization;


namespace data_viewer.services
{
    public class CustomAuthenticationService
    {
        private ConfigurationService _config;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage,
            ConfigurationService config)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _config = config;
        }
        public async Task<LoginResult> Login(LoginCredential credential)
        {
            //application/json
            //application/x-www-form-urlencoded
            
            var requestContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("password", credential.password),
                new KeyValuePair<string, string>("username", credential.username),
                new KeyValuePair<string, string>("grant_type", credential.grant_type),
                
            });
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes("docker_mon_client:gama-monitor")));
            var loginAsJson = JsonSerializer.Serialize(credential);
            var response = await _httpClient.PostAsync(
                _config.hostName + "/oauth/token", 
                requestContent);
            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                loginResult.Successful = false;
                return loginResult;
            }
            //Console.WriteLine(loginResult.access_token);
            await _localStorage.SetItemAsync("authToken", loginResult.access_token);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(credential.username);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.access_token);
            loginResult.Successful = true;
            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
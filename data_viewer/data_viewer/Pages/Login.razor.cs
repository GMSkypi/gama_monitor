using System;
using data_viewer.Model;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace data_viewer.Pages
{
    public partial class Login : ComponentBase, IDisposable
    {
        [Inject]
        private CustomAuthenticationService customAuthenticationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        public void Dispose()
        {
        }
        async void OnLogin(LoginArgs args)
        {
            var result = await customAuthenticationService.Login(new LoginCredential(args.Username, args.Password, "password"));

            if (result.Successful)
            {
                NavigationManager.NavigateTo("/dashboard");
            }
            else
            {
                Console.WriteLine(result.error_description);
            }
        }

    }
}
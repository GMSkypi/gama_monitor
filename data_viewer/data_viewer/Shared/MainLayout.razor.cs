using System;
using System.Threading.Tasks;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace data_viewer.Shared
{
    public partial class MainLayout
    {
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private AuthenticationStateProvider authenticationStateProvider { get; set; }
        
        [Inject] private CustomAuthenticationService customAuthenticationService { get; set; }

        private bool collapsed = false;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            
            var user = (await authenticationStateProvider.GetAuthenticationStateAsync()).User;
            if(!user.Identity.IsAuthenticated)
            {
                navigationManager.NavigateTo($"/login");
            }
             
        }

        private void ToggleSidebarOut()
        {
            collapsed = false;
            StateHasChanged();
        }
        private void ToggleSidebarIn()
        {
            collapsed = true;
            StateHasChanged();
        }
        private void Logout()
        {
            customAuthenticationService.Logout();
            navigationManager.NavigateTo($"/login");
        }
        
    }
}
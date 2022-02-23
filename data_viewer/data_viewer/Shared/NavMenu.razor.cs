using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace data_viewer.Shared
{
    public partial class NavMenu
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private CustomAuthenticationService CustomAuthenticationService { get; set; }
        
        private bool collapseNavMenu = true;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        private void logout()
        {
            CustomAuthenticationService.Logout();
            NavigationManager.NavigateTo($"/login");
        }
    }
}
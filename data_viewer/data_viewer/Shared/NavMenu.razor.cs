using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace data_viewer.Shared
{
    public partial class NavMenu
    {
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private CustomAuthenticationService customAuthenticationService { get; set; }
        
        private bool _collapseNavMenu = true;

        private string navMenuCssClass => _collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }

        private void Logout()
        {
            customAuthenticationService.Logout();
            navigationManager.NavigateTo($"/login");
        }
    }
}
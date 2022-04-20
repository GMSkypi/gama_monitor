using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace data_viewer.Shared
{
    public partial class NavMenu
    {

        private bool _collapseNavMenu = true;

        private string navMenuCssClass => _collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            _collapseNavMenu = !_collapseNavMenu;
        }
    }
}
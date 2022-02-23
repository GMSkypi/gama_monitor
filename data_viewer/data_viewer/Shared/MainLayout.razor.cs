using System.Threading.Tasks;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace data_viewer.Shared
{
    public partial class MainLayout
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        protected async override Task OnInitializedAsync()
        {
            base.OnInitialized();
            
            var user = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User;
            if(!user.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo($"/login");
            }
             
        }
    }
}
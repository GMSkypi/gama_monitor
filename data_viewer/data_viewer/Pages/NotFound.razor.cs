using System;
using Microsoft.AspNetCore.Components;

namespace data_viewer.Pages
{
    public partial class NotFound : ComponentBase, IDisposable
    {
        [Inject] public NavigationManager navigationManager { get; set; }
        
        protected override void OnInitialized()
        {
            navigationManager.NavigateTo($"/dashboard");
        }
        
        public void Dispose()
        {
        }
    }
}
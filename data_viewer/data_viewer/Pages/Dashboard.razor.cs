using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data_viewer.Model;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;


namespace data_viewer.Pages
{
    public partial class Dashboard : ComponentBase, IDisposable
    {
        [Inject] public NavigationManager navigationManager { get; set; }

        [Inject] public ContainerComService containerComService { get; set; }

        private IEnumerable<Container> _data = new List<Container>();

        private async Task LoadData()
        {
            _data = await containerComService.GetContainers();
            Console.WriteLine("Dashboard container loaded: " + _data.Count());
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
            StateHasChanged();
        }

        public void Dispose()
        {
        }
    }
}
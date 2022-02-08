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
    public partial class Dashboard  : ComponentBase, IDisposable
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        [Inject]
        public ContainerComService ContainerComService { get; set; }

        private IEnumerable<Container> data = new List<Container>();
        
        async Task LoadData()
        {
            data = await ContainerComService.getContainers();
            Console.WriteLine("Dashboard container loaded: " + data.Count());
        }
         protected  async override Task OnInitializedAsync()
         {
              await LoadData();
              StateHasChanged();
         }

        
        public void Dispose()
        {
        }
    }
}
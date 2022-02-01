
using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using data_viewer.Model;
using data_viewer.services;
using Radzen;
using Radzen.Blazor;


namespace data_viewer.Pages
{
    public partial class ContainerList : ComponentBase, IDisposable
    {
        protected RadzenDataGrid<Container> grid;
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        [Inject]
        public ContainerComService ContainerComService { get; set; }
        
        
        public void Dispose()
        {
        }
        
        IEnumerable<Container> data;
        protected IList<Container> SelectedContainer { get; set; }
        RadzenDataGrid<Container> _dataGrid;
        int count;
        bool isLoading;

        async Task LoadData(LoadDataArgs args)
        {
            isLoading = true;
            data = await ContainerComService.getContainers();
            count = data.Count();
            isLoading = false;
        }
        protected void OnItemClick(DataGridRowMouseEventArgs<Container> e)
        {
            NavigationManager.NavigateTo($"/ContainerDetail/{e.Data.id}");
        }
        
    }
}
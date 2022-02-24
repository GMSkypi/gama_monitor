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
        [Inject] public NavigationManager navigationManager { get; set; }

        [Inject] public ContainerComService containerComService { get; set; }

        [Inject] public NotificationService notificationService { get; set; }

        private IEnumerable<Container> _data;
        private IList<Container> selectedContainer { get; set; }
        private RadzenDataGrid<Container> _dataGrid;
        private int _count;
        private bool _isLoading;

        async Task LoadData(LoadDataArgs args)
        {
            _isLoading = true;
            _data = await containerComService.GetContainers();
            _count = _data.Count();
            _isLoading = false;
        }

        private void OnItemClick(DataGridRowMouseEventArgs<Container> e)
        {
            navigationManager.NavigateTo($"/ContainerDetail/{e.Data.id}");
        }

        public void Dispose()
        {
        }
    }
}
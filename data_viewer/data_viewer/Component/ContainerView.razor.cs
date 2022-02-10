using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.services;
using Microsoft.AspNetCore.Components;

namespace data_viewer.Component
{
    public partial class ContainerView: ComponentBase, IDisposable
    {
        [Parameter]
        public Container container { get; set; }
        [Inject] 
        public CPUComService cpuComService { get; set; }
        
        [Inject]
        public MemoryComService memoryComService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        public IEnumerable<CpuSample> cpuData { get; set; }
        
        public IEnumerable<MemorySample> memoryData { get; set; }
        
        async Task LoadData()
        {
            Console.WriteLine("loading");
            cpuData = await cpuComService.getCpuSamples(container.id, new DateTime(2022, 1, 14, 12,41,00),DataSamplingRates.hour);
            memoryData = await memoryComService.getMemorySample(container.id, new DateTime(2022, 1, 14, 12, 41, 00),
                DataSamplingRates.hour);
            StateHasChanged();
            Console.WriteLine("loaded");
        }
        protected async override Task OnInitializedAsync()
        {
            await LoadData();
            Console.WriteLine(container.id);
        }
        public void Dispose()
        {
        }

        protected void DetailClick()
        {
            NavigationManager.NavigateTo($"/ContainerDetail/{container.id}");
        }
    }
}
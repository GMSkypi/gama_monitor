using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using data_viewer.Model.Rate;

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
        [Inject]
        public ContainerComService containerComService { get; set; }
        
        public IEnumerable<CpuSample> cpuData { get; set; }
        
        public IEnumerable<MemorySample> memoryData { get; set; }
        
        private DateTime? dateTimeDatePicker;
        private System.Threading.Timer timer;
        private bool notRunning = false;
        
        /*
        async Task LoadData()
        {
            Console.WriteLine("loading");
            cpuData = await cpuComService.getCpuSamples(container.id, new DateTime(2022, 1, 14, 12,41,00),DataSamplingRates.hour);
            memoryData = await memoryComService.getMemorySample(container.id, new DateTime(2022, 1, 14, 12, 41, 00),
                DataSamplingRates.hour);
            StateHasChanged();
            Console.WriteLine("loaded");
        }
        */
        async Task LoadData(DateTime from, SampledBy sampled)
        {
            cpuData = await cpuComService.getCpuSamples(container.id, from, sampled);
            memoryData = await memoryComService.getMemorySample(container.id, from, sampled);
        }

        protected void LiveInitialized()
        {
            timer = new System.Threading.Timer(async (object stateInfo) =>
            {
                if (notRunning)
                {
                    container = await containerComService.getContainer(container.id);
                    if (container != null && container.lastRecord > DateTime.Now.AddHours(-1)) notRunning = false;
                    return;
                }
                await LoadData(DateTime.Now.AddMinutes(-10), DataSamplingRates.minute);
                if (!cpuData.Any())
                {
                    notRunning = true;
                    StateHasChanged();
                }

            }, new System.Threading.AutoResetEvent(false), 0, 20000);
        }
        protected async override Task OnInitializedAsync()
        {
            dateTimeDatePicker = DateTime.Now.AddHours(-1);
            LiveInitialized();
        }
        public void Dispose()
        {
            timer.Dispose();
        }

        protected void DetailClick()
        {
            NavigationManager.NavigateTo($"/ContainerDetail/{container.id}");
        }
    }
}
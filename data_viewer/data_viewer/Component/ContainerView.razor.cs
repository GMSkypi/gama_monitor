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
    public partial class ContainerView : ComponentBase, IDisposable
    {
        [Parameter] public Container container { get; set; }
        [Inject] public CPUComService cpuComService { get; set; }
        [Inject] public MemoryComService memoryComService { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        [Inject] public ContainerComService containerComService { get; set; }

        private IEnumerable<CpuSample> _cpuData { get; set; }
        private IEnumerable<MemorySample> _memoryData { get; set; }
        private DateTime? _dateTimeDatePicker;
        private System.Threading.Timer _timer;
        private bool _notRunning = false;

        private async Task LoadData(DateTime from, SampledBy sampled)
        {
            _cpuData = await cpuComService.GetCpuSamples(container.id, from, sampled);
            _memoryData = await memoryComService.GetMemorySample(container.id, from, sampled);
        }

        private void LiveInitialized()
        {
            _timer = new System.Threading.Timer(async _ =>
            {
                if (_notRunning)
                {
                    container = await containerComService.GetContainer(container.id);
                    if (container != null && container.lastRecord > DateTime.Now.AddHours(-1)) _notRunning = false;
                    return;
                }

                await LoadData(DateTime.Now.AddMinutes(-10), DataSamplingRates.Minute);
                if (!_cpuData.Any())
                {
                    _notRunning = true;
                    StateHasChanged();
                }
            }, new System.Threading.AutoResetEvent(false), 0, 20000);
        }

        protected override void OnInitialized()
        {
            _dateTimeDatePicker = DateTime.Now.AddHours(-1);
            LiveInitialized();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void DetailClick()
        {
            navigationManager.NavigateTo($"/ContainerDetail/{container.id}");
        }
    }
}
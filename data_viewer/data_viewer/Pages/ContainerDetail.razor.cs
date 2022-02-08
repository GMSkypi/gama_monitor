using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data_viewer.Component;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.Model.Notification;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace data_viewer.Pages
{
    public partial class ContainerDetail : ComponentBase, IDisposable
    {
        [Parameter]
        public String ContainerId { get; set; }
        [Inject]
        public DialogService DialogService { get; set; }

        [Inject] 
        public CPUComService cpuComService { get; set; }
        
        [Inject]
        public MemoryComService memoryComService { get; set; }
        
        [Inject]
        public NetComService netComService { get; set; }
        
        [Inject]
        public IOComService ioComService { get; set; }
        
        [Inject] private NotificationComService notificationComService { get; set; }
        
        IEnumerable<CpuSample> cpuData;
        int value = 0;
        private CpuSample lastCpuSample = new CpuSample();

        private IEnumerable<MemorySample> memoryData;
        private MemorySample lastMemorySample = new MemorySample();
        
        private IEnumerable<NetSample> netData;
        private NetSample lastNetSample = new NetSample();
        
        private IEnumerable<IOSample> ioData;
        private IOSample lastioSample = new IOSample();
        
        public void Dispose()
        {
        }
        async Task LoadData()
        {
            Console.WriteLine("loading");
            cpuData = await cpuComService.getCpuSamples(ContainerId, new DateTime(2022, 1, 14, 12,41,00),DataSamplingRates.hour);
            memoryData = await memoryComService.getMemorySample(ContainerId, new DateTime(2022, 1, 14, 12, 41, 00),
                DataSamplingRates.hour);
            ioData = await ioComService.getIOSamples(ContainerId, new DateTime(2022, 1, 14, 12,41,00),DataSamplingRates.hour);
            netData = await netComService.getNetSample(ContainerId, new DateTime(2022, 1, 14, 12,41,00),DataSamplingRates.hour);
            
            lastCpuSample = cpuData.Last();
            lastMemorySample = memoryData.Last();
            lastioSample = ioData.Last();
            lastNetSample = netData.Last();
            StateHasChanged();
            Console.WriteLine("loaded");
        }

        protected override void OnInitialized()
        {
            LoadData();
            Console.WriteLine(ContainerId);
        }
        void OnDateTimeChange(DateTime? value, string name, string format)
        {
            Console.WriteLine($"{name} value changed to {value?.ToString(format)}");
        }
        void OnSampleRateChange(int value, string name)
        {
            Console.WriteLine($"{name} value changed to {string.Join(", ", value)}");
        }
        async void AddNotificationOnClick()
        {
            Notification newNotification = new Notification();
            newNotification.containerId = ContainerId;
            bool edited = await DialogService.OpenAsync<EditNotificationDialog>($"Add notification",
                new Dictionary<string, Object>() { { "Notification", newNotification } },
                new DialogOptions() { Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false });
            if (edited)
            {
                await notificationComService.createNotification(newNotification);
            }
        }
    }
}
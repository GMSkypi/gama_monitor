using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Inject]
        public NotificationService NotificationService { get; set; }
        
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
            cpuData = await cpuComService.getCpuSamples(ContainerId, new DateTime(2022, 1, 14, 12,41,00),
                new DateTime(2022, 1, 14, 13 ,41,00),DataSamplingRates.hour);
            memoryData = await memoryComService.getMemorySample(ContainerId, new DateTime(2022, 1, 14, 12, 41, 00),
                new DateTime(2022, 1, 14, 13 ,41,00),
                DataSamplingRates.hour);
            ioData = await ioComService.getIOSamples(ContainerId, new DateTime(2022, 1, 14, 12,41,00),
                new DateTime(2022, 1, 14, 13 ,41,00),DataSamplingRates.hour);
            netData = await netComService.getNetSample(ContainerId, new DateTime(2022, 1, 14, 12,41,00),
                new DateTime(2022, 1, 14, 13 ,41,00),DataSamplingRates.hour);
            
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
        void OnDateTimeChange(DateTime? value, string format)
        {
           
        }
        void OnSampleRateChange(int value)
        {
            switch (value)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
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
                Notification updatedNotification = await notificationComService.createNotification(newNotification);
                if (updatedNotification != null)
                {
                    NotificationMessage message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Success, Summary = "Notification added", Detail = "Notification with id:" + updatedNotification.id + " is added",
                        Duration = 5000,
                    };
                    NotificationService.Notify(message);
                }
                else
                {
                    NotificationMessage message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Error, Summary = "Notification adding failed",
                        Duration = 5000,
                    };
                    NotificationService.Notify(message);
                }
            }
        }
    }
}
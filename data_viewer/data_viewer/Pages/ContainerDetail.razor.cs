using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using data_viewer.Component;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.Model.Notification;
using data_viewer.Model.Rate;
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

        private DateTime? dateTimeDatePicker;
        private System.Threading.Timer timer;
        
        
        public void Dispose()
        {
            timer.Dispose();
        }
        async Task LoadData(DateTime from, SampledBy sampled, DateTime? to = null)
        {
            Console.WriteLine("loading");
            if (to.HasValue)
            {
                cpuData = await cpuComService.getCpuSamples(ContainerId, from, to.Value,sampled);
                memoryData = await memoryComService.getMemorySample(ContainerId, from, to.Value,sampled);
                ioData = await ioComService.getIOSamples(ContainerId, from, to.Value,sampled);
                netData = await netComService.getNetSample(ContainerId, from, to.Value,sampled);
            }
            else
            {
                cpuData = await cpuComService.getCpuSamples(ContainerId, from,sampled);
                memoryData = await memoryComService.getMemorySample(ContainerId, from,sampled);
                ioData = await ioComService.getIOSamples(ContainerId, from,sampled);
                netData = await netComService.getNetSample(ContainerId, from,sampled);
            }
            
            if (cpuData != null || cpuData.Any())
            {
                lastCpuSample = cpuData.Last();
                lastMemorySample = memoryData.Last();
                lastioSample = ioData.Last();
                lastNetSample = netData.Last();
                
            }
            else
            {
                lastCpuSample = null;   
                lastMemorySample = null;
                lastioSample = null;
                lastNetSample = null;
            }
            StateHasChanged();
            Console.WriteLine("loaded");
        }

        protected override void OnInitialized()
        {
            dateTimeDatePicker = DateTime.Now.AddHours(-1);
            LiveInitialized();
            /*
            LoadData(new DateTime(2022, 1, 14, 12,41,00),
                new DateTime(2022, 1, 14, 13 ,41,00),
                DataSamplingRates.hour);
                
            */
            
        }

        protected void LiveInitialized()
        {
            timer = new System.Threading.Timer(async (object stateInfo) =>
            {
                LoadData(DateTime.Now.AddMinutes(-10), DataSamplingRates.minute);
            }, new System.Threading.AutoResetEvent(false), 0, 20000);
        }

        protected void CommonInitialized(DateTime beforeActualTime, SampledBy sampledBy, DateTime afterTime)
        {
            if (dateTimeDatePicker > beforeActualTime)
            {
                LoadData(beforeActualTime,sampledBy);
                return;
            }
            LoadData(dateTimeDatePicker.Value,sampledBy, afterTime);
        }
        void OnDateTimeChange(DateTime? value, string format)
        {
            OnSampleRateChange(this.value);
        }
        void OnSampleRateChange(int value)
        {
            if (value != 0)
            {
                timer.Dispose();
            }
            switch (value)
            {
                case 0: // live
                    LiveInitialized();
                    break;
                case 1: //Hour
                    CommonInitialized(DateTime.Now.AddHours(-1), DataSamplingRates.hour,
                        dateTimeDatePicker.Value.AddHours(1));
                    break;
                case 2: // Day
                    CommonInitialized(DateTime.Now.AddDays(-1), DataSamplingRates.day,
                        dateTimeDatePicker.Value.AddDays(1));
                    break;
                case 3: // Month
                    CommonInitialized(DateTime.Now.AddMonths(-1), DataSamplingRates.month,
                        dateTimeDatePicker.Value.AddMonths(1));
                    break;
                case 4: // Year
                    CommonInitialized(DateTime.Now.AddYears(-1), DataSamplingRates.year,
                        dateTimeDatePicker.Value.AddYears(1));
                    break;
                case 5: // All
                    LoadData(DateTime.UnixEpoch,DataSamplingRates.inf);
                    break;
            }
        }
        async void AddNotificationOnClick()
        {
            Notification newNotification = new Notification();
            newNotification.containerId = ContainerId;
            bool? edited = await DialogService.OpenAsync<EditNotificationDialog>($"Add notification",
                new Dictionary<string, Object>() { { "Notification", newNotification } },
                new DialogOptions() { Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false  });
            if (edited.HasValue && edited.Value)
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
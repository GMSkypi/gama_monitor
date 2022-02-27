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
using Container = data_viewer.Model.Container;

namespace data_viewer.Pages
{
    public partial class ContainerDetail : ComponentBase, IDisposable
    {
        [Parameter] public String containerId { get; set; }

        private Container _container;

        [Inject] public DialogService dialogService { get; set; }

        [Inject] public CPUComService cpuComService { get; set; }

        [Inject] public MemoryComService memoryComService { get; set; }

        [Inject] public NetComService netComService { get; set; }

        [Inject] public IOComService ioComService { get; set; }
        [Inject] public NotificationService notificationService { get; set; }

        [Inject] public ContainerComService containerComService { get; set; }

        [Inject] private NotificationComService notificationComService { get; set; }

        private IEnumerable<CpuSample> _cpuData;
        private int _value = 0;
        private CpuSample _lastCpuSample = new CpuSample();

        private IEnumerable<MemorySample> _memoryData;
        private MemorySample _lastMemorySample = new MemorySample();

        private IEnumerable<NetSample> _netData;
        private NetSample _lastNetSample = new NetSample();

        private IEnumerable<IOSample> _ioData;
        private IOSample _lastioSample = new IOSample();

        private DateTime? _dateTimeDatePicker;
        private System.Threading.Timer _timer;

        private bool _notRunning = false;

        public void Dispose()
        {
            _timer.Dispose();
        }

        async Task LoadData(DateTime from, SampledBy sampled, DateTime? to = null)
        {
            Console.WriteLine("loading");
            if (to.HasValue)
            {
                _cpuData = await cpuComService.GetCpuSamples(containerId, from, to.Value, sampled);
                _memoryData = await memoryComService.GetMemorySample(containerId, from, to.Value, sampled);
                _ioData = await ioComService.GetIoSamples(containerId, from, to.Value, sampled);
                _netData = await netComService.GetNetSample(containerId, from, to.Value, sampled);
            }
            else
            {
                _cpuData = await cpuComService.GetCpuSamples(containerId, from, sampled);
                _memoryData = await memoryComService.GetMemorySample(containerId, from, sampled);
                _ioData = await ioComService.GetIoSamples(containerId, from, sampled);
                _netData = await netComService.GetNetSample(containerId, from, sampled);
            }

            if (_cpuData != null && _cpuData.Any())
            {
                _lastCpuSample = _cpuData.Last();
                _lastMemorySample = _memoryData.Last();
                _lastioSample = _ioData.Last();
                _lastNetSample = _netData.Last();
            }
            else
            {
                _lastCpuSample = null;
                _lastMemorySample = null;
                _lastioSample = null;
                _lastNetSample = null;
            }

            StateHasChanged();
            Console.WriteLine("loaded");
        }

        protected override void OnInitialized()
        {
            LiveInitialized();
        }

        private void LiveInitialized()
        {
            _timer = new System.Threading.Timer(async (object stateInfo) =>
            {
                if (_notRunning)
                {
                    _container = await containerComService.GetContainer(containerId);
                    if (_container != null && _container.lastRecord > DateTime.UtcNow.AddHours(-1)) _notRunning = false;
                    return;
                }

                await LoadData(DateTime.UtcNow.AddMinutes(-10), DataSamplingRates.Minute);
                if (_cpuData.Any()) return;
                _notRunning = true;
                _container = await containerComService.GetContainer(containerId);
                StateHasChanged();
            }, new System.Threading.AutoResetEvent(false), 0, 20000);
        }

        private void CommonInitialized(DateTime beforeActualTime, SampledBy sampledBy, DateTime afterTime)
        {
            if (_dateTimeDatePicker > beforeActualTime)
            {
                LoadData(beforeActualTime, sampledBy);
                return;
            }

            LoadData(_dateTimeDatePicker.Value, sampledBy, afterTime);
        }

        private void OnDateTimeChange(DateTime? value, string format)
        {
            OnSampleRateChange(this._value);
        }

        private async void OnSampleRateChange(int value)
        {
            if (value != 0)
            {
                await _timer.DisposeAsync();
            }
            if (_dateTimeDatePicker == null)
            {
                var message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Date is not correctly specified",
                    Duration = 5000,
                };
                notificationService.Notify(message);
                _dateTimeDatePicker = DateTime.UtcNow.AddHours(-1);
            }

            switch (value)
            {
                case 0: // live
                    LiveInitialized();
                    break;
                case 1: //Hour
                    CommonInitialized(DateTime.UtcNow.AddHours(-1), DataSamplingRates.Hour,
                        _dateTimeDatePicker.Value.AddHours(1));
                    break;
                case 2: // Day
                    CommonInitialized(DateTime.UtcNow.AddDays(-1), DataSamplingRates.Day,
                        _dateTimeDatePicker.Value.AddDays(1));
                    break;
                case 3: // Month
                    CommonInitialized(DateTime.UtcNow.AddMonths(-1), DataSamplingRates.Month,
                        _dateTimeDatePicker.Value.AddMonths(1));
                    break;
                case 4: // Year
                    CommonInitialized(DateTime.UtcNow.AddYears(-1), DataSamplingRates.Year,
                        _dateTimeDatePicker.Value.AddYears(1));
                    break;
                case 5: // All
                    await LoadData(DateTime.UnixEpoch, DataSamplingRates.Inf);
                    break;
            }
        }

        private async void AddNotificationOnClick()
        {
            Notification newNotification = new Notification {containerId = containerId};
            bool? edited = await dialogService.OpenAsync<EditNotificationDialog>($"Add notification",
                new Dictionary<string, Object>() {{"Notification", newNotification}},
                new DialogOptions() {Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false});
            if (!edited.HasValue || !edited.Value) return;
            var updatedNotification = await notificationComService.CreateNotification(newNotification);
            if (updatedNotification != null)
            {
                var message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Success, Summary = "Notification added",
                    Detail = "Notification with id:" + updatedNotification.id + " is added",
                    Duration = 5000,
                };
                notificationService.Notify(message);
            }
            else
            {
                var message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Notification adding failed",
                    Duration = 5000,
                };
                notificationService.Notify(message);
            }
        }
    }
}
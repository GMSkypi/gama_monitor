using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using data_viewer.Component;
using data_viewer.Extension;
using data_viewer.Model;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using Group = data_viewer.Model.Notification.Group;


namespace data_viewer.Pages
{
    public partial class DataRemoval : ComponentBase, IDisposable
    {
        [Inject] public NavigationManager navigationManager { get; set; }

        [Inject] public ContainerComService containerComService { get; set; }

        [Inject] public NotificationService notificationService { get; set; }

        [Inject] public DialogService dialogService { get; set; }
        [Inject] public CPUComService cpuComService { get; set; }

        [Inject] public MemoryComService memoryComService { get; set; }

        [Inject] public NetComService netComService { get; set; }

        [Inject] public IOComService ioComService { get; set; }


        private List<EnumExtension<Group>> _enumGroups = new();

        private IEnumerable<Container> _data;
        private RadzenDataGrid<Container> _dataGrid;
        private int _count;
        private bool _isLoading;
        private DateTime? _dateTimeDatePicker;

        protected override async void OnInitialized()
        {
            _enumGroups = EnumExtension<Group>.GetAllEnumExtension();
            _dateTimeDatePicker = DateTime.UtcNow.AddMonths(-2);
            await LoadData();
            StateHasChanged();
        }

        private void OnDateTimeChange(DateTime? value, string format)
        {
        }

        private async Task RemoveContainer(Container container)
        {
            bool? result = await dialogService.OpenAsync<ConfirmationDialog>($"Remove container",
                new Dictionary<string, Object>() {{"Message", "Remove container: " + container.id}},
                new DialogOptions() {Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false});
            if (result.HasValue && result.Value)
            {
                bool deleted = await containerComService.DeleteContainer(container.id);
                if (deleted)
                {
                    _data = _data.Where(unUpdated => unUpdated.id != container.id);
                    var message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Success, Summary = "Container is removed",
                        Detail = "Container " + container.id + " is removed successfully",
                        Duration = 4000
                    };
                    notificationService.Notify(message);
                }
                else
                {
                    var message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Error, Summary = "Container is not removed",
                        Detail = "Container " + container.id + " is still present",
                        Duration = 5000,
                    };
                    notificationService.Notify(message);
                }
            }
        }

        private async Task RemoveMetricData(EnumExtension<Group> metric)
        {
            if (_dateTimeDatePicker == null)
            {
                var message = new NotificationMessage()
                {
                    Severity = NotificationSeverity.Error, Summary = "Date is not correctly specified",
                    Duration = 5000,
                };
                notificationService.Notify(message);
                return;
            }
            bool? result = await dialogService.OpenAsync<ConfirmationDialog>($"Remove metric",
                new Dictionary<string, Object>()
                {
                    {
                        "Message",
                        "Remove " + metric.enumName + " metric from: " + DateTime.UnixEpoch + " to: " +
                        _dateTimeDatePicker
                    }
                },
                new DialogOptions() {Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false});
            if (result.HasValue && result.Value)
            {
                bool deleted = metric.enumValue switch
                {
                    Group.IO => await ioComService.DeleteIOData(_dateTimeDatePicker.Value),
                    Group.CPU => await cpuComService.DeleteCpuData(_dateTimeDatePicker.Value),
                    Group.NET => await netComService.DeleteNetData(_dateTimeDatePicker.Value),
                    Group.MEMORY => await memoryComService.DeleteMemoryData(_dateTimeDatePicker.Value),
                    _ => throw new ArgumentOutOfRangeException()
                };
                if (deleted)
                {
                    var message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Success, Summary = "Containers data is removed",
                        Detail = "Metric " + metric.enumName + " from: " + DateTime.UnixEpoch + " to: "+  _dateTimeDatePicker + " is removed",
                        Duration = 4000
                    };
                    notificationService.Notify(message);
                }
                else
                {
                    var message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Error, Summary = "Containers data is not removed",
                        Detail = "Metric " + metric.enumName + " from: " + DateTime.UnixEpoch + " to: "+  _dateTimeDatePicker + " is not removed",
                        Duration = 5000,
                    };
                    notificationService.Notify(message);
                }
            }
        }

        async Task LoadData()
        {
            _isLoading = true;
            _data = await containerComService.GetContainers();
            _count = _data.Count();
            _isLoading = false;
        }

        public void Dispose()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using data_viewer.Component;
using data_viewer.Model;
using data_viewer.Model.Notification;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace data_viewer.Pages
{
    public partial class NotificationsList : ComponentBase, IDisposable
    {
        [Inject] private NotificationComService notificationComService { get; set; }

        [Inject] public DialogService dialogService { get; set; }

        [Inject] public NotificationService notificationService { get; set; }

        private IEnumerable<Notification> _data;
        private RadzenDataGrid<Notification> _dataGrid;
        private int _count;
        private bool _isLoading;

        public void Dispose()
        {
        }

        private async Task LoadData(LoadDataArgs args)
        {
            _isLoading = true;
            _data = await notificationComService.GetNotifications();
            _count = _data.Count();
            _isLoading = false;
        }

        private async Task EditNotificationOnItemClick(Notification notification)
        {
            bool? edited = await dialogService.OpenAsync<EditNotificationDialog>($"Edit notification",
                new Dictionary<string, Object>() {{"Notification", notification}},
                new DialogOptions() {Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false});
            if (edited.HasValue && edited.Value)
            {
                var updateNotification = await notificationComService.UpdateNotification(notification);
                if (updateNotification != null)
                {
                    var message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Success, Summary = "Notification edited successfully",
                        Detail = "Notification with id:" + updateNotification.id + " is updated",
                        Duration = 5000,
                    };
                    notificationService.Notify(message);
                }
                else
                {
                    var message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Error, Summary = "Notification edited failed",
                        Duration = 5000,
                    };
                    notificationService.Notify(message);
                }
            }
        }

        private async Task RemoveNotification(Notification notification)
        {
            bool? result = await dialogService.OpenAsync<ConfirmationDialog>($"Remove notification",
                new Dictionary<string, Object>() {{"Message", "Remove Notification: " + notification.id}},
                new DialogOptions() {Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false});
            if (result.HasValue && result.Value)
            {
                bool deleted = await notificationComService.DeleteNotification(notification.id.ToString());
                if (deleted)
                {
                    _data = _data.Where(unUpdated => unUpdated.id != notification.id);
                    var message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Success, Summary = "Notification removed",
                        Detail = "Notification " + notification.id + " removed successfully",
                        Duration = 4000
                    };
                    notificationService.Notify(message);
                }
                else
                {
                    var message = new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Error, Summary = "Notification removing failed",
                        Detail ="Notification " + notification.id + "is still present",
                        Duration = 5000,
                    };
                    notificationService.Notify(message);
                }
            }
        }
    }
}
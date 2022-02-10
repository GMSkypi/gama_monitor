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
        
        [Inject]
        public DialogService DialogService { get; set; }
        
        [Inject]
        public NotificationService NotificationService { get; set; }
        
        IEnumerable<Notification> data;
        protected IList<Notification> SelectedNotification { get; set; }
        RadzenDataGrid<Notification> _dataGrid;
        int count;
        bool isLoading;
        
        public void Dispose()
        {
        }
        async Task LoadData(LoadDataArgs args)
        {
            isLoading = true;
            data = await notificationComService.getNotifications();
            count = data.Count();
            isLoading = false;
        }
        protected async Task EditNotificationOnItemClick(Notification notif)
        {
            bool edited = await DialogService.OpenAsync<EditNotificationDialog>($"Edit notification",
                new Dictionary<string, Object>() { { "Notification", notif } },
                new DialogOptions() { Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false });
            if (edited)
            {
                Notification updateNotification = await notificationComService.updateNotification(notif);
            }
        }
        protected async Task removeNotification(Notification notification)
        {
            bool result = await DialogService.OpenAsync<ComfirmationDialog>($"Remove notification",
                new Dictionary<string, Object>() { { "Message", "Remove Notification: " + notification.id } },
                new DialogOptions() { Width = "600px", Height = "fit-content", CloseDialogOnOverlayClick = false });
            if (result)
            {
                bool deleted = await notificationComService.deleteNotification(notification.id.ToString());
                if (deleted)
                {
                    data = data.Where(unupdatedNotif => unupdatedNotif.id != notification.id);
                    NotificationsList message = new NotificationsList()
                    {
                        Severity = NotificationSeverity.Success, Summary = "Success Summary", Detail = "Success Detail",
                        Duration = 4000
                    };
                    NotificationService.Notify(message);
                }
            }
        }
    }
}

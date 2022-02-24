using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.Model.Notification;
using Radzen;

namespace data_viewer.services
{
    public class NotificationComService : CommunicationService
    {
        public NotificationComService(ConfigurationService config, NotificationService notificationService, HttpClient httpClient) : base(config,notificationService,httpClient)
        {
        }

        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            var uri = new Uri(config.hostName + EndpointConstants.NotificationsUrl);
            return await ExecuteRequestMultiple<Notification>(uri, HttpMethod.Get);
        }

        public async Task<Notification> GetNotification(string id)
        {
            var uri = new Uri(config.hostName + EndpointConstants.NotificationUrl + id);
            return await ExecuteRequestSingle<Notification>(uri, HttpMethod.Get);
        }

        public async Task<bool> DeleteNotification(string id)
        {
            var uri = new Uri(config.hostName + EndpointConstants.NotificationUrl + id);
            return await ExecuteNoresponse(uri, HttpMethod.Delete);
        }

        public async Task<Notification> CreateNotification(Notification notification)
        {
            var uri = new Uri(config.hostName + EndpointConstants.NotificationUrl);
            return await ExecuteRequestSingle<Notification>(uri, HttpMethod.Post, notification);
        }
        public async Task<Notification> UpdateNotification(Notification notification)
        {
            var uri = new Uri(config.hostName + EndpointConstants.NotificationUrl);
            return await ExecuteRequestSingle<Notification>(uri, HttpMethod.Patch, notification);
        }
        
    }
}
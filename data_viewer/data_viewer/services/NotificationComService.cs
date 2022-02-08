using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.Model.Notification;

namespace data_viewer.services
{
    public class NotificationComService : CommunicationService
    {
        public NotificationComService(ConfigurationService config) : base(config)
        {
        }

        public async Task<IEnumerable<Notification>> getNotifications()
        {
            var uri = new Uri(config.hostName + EndpointConstants.notificationsURL);
            return await executeRequestMultiple<Notification>(uri, HttpMethod.Get);
        }

        public async Task<Notification> getNotification(String id)
        {
            var uri = new Uri(config.hostName + EndpointConstants.notificationURL + id);
            return await executeRequestSingle<Notification>(uri, HttpMethod.Get);
        }

        public async Task<bool> deleteNotification(String id)
        {
            var uri = new Uri(config.hostName + EndpointConstants.notificationURL + id);
            return await executeNoresponse(uri, HttpMethod.Delete);
        }

        public async Task<Notification> createNotification(Notification notification)
        {
            var uri = new Uri(config.hostName + EndpointConstants.notificationURL);
            return await executeRequestSingle<Notification>(uri, HttpMethod.Post, notification);
        }
        public async Task<Notification> updateNotification(Notification notification)
        {
            var uri = new Uri(config.hostName + EndpointConstants.notificationURL);
            return await executeRequestSingle<Notification>(uri, HttpMethod.Patch, notification);
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using data_viewer.Constants;
using data_viewer.Model;
using Radzen;

namespace data_viewer.services
{
    public class UserService : CommunicationService
    {
        public UserService(ConfigurationService config, NotificationService notificationService, HttpClient httpClient) : base(config, notificationService, httpClient)
        {
        }

        public async Task<bool> changeUsername(String newUsername)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.usernameChangeURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["username"] = newUsername;
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<bool>(url, HttpMethod.Post);
            return (result != null) ? result : false;
        }

        public async Task<bool> changePassword(String newPassword)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.passwordChangeURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["password"] = newPassword;
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<bool>(url, HttpMethod.Post);
            return (result != null) ? result : false;
        }
        
        
    }
}
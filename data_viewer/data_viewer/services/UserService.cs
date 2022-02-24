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

        public async Task<bool> ChangeUsername(String newUsername)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.UsernameChangeUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[EpAttributeConstants.Username] = newUsername;
            builder.Query = query.ToString();
            var url = builder.Uri;
            return await ExecuteRequestSingle<bool>(url, HttpMethod.Post);
        }

        public async Task<bool> ChangePassword(String newPassword)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.PasswordChangeUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[EpAttributeConstants.Password] = newPassword;
            builder.Query = query.ToString();
            var url = builder.Uri;
            return await ExecuteRequestSingle<bool>(url, HttpMethod.Post);
        }
        
        
    }
}
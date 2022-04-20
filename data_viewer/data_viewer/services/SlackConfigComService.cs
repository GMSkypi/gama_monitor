using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using data_viewer.Constants;
using data_viewer.Model;
using Radzen;

namespace data_viewer.services
{
    public class SlackConfigComService : CommunicationService
    {
        public SlackConfigComService(ConfigurationService config, NotificationService notificationService, HttpClient httpClient) : base(config,notificationService,httpClient)
        {
        }

        public async Task<SlackConf> GetSlackServerConf()
        {
            var uri = new Uri(config.hostName + EndpointConstants.SlackUrl);
            return await ExecuteRequestSingle<SlackConf>(uri, HttpMethod.Get);
        }

        public async Task<bool> SetSlackServerUrl(String newSlackUrl)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.SlackUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[EpAttributeConstants.Url] = newSlackUrl;
            builder.Query = query.ToString();
            var url = builder.Uri;
            return await ExecuteNoresponse(url, HttpMethod.Post);
        }
        public async Task<bool> SetSlackServerActiveFlag(bool activeFlag)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.SlackActiveUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[EpAttributeConstants.Active] = activeFlag.ToString();
            builder.Query = query.ToString();
            var url = builder.Uri;
            return await ExecuteNoresponse(url, HttpMethod.Post);
        }
        
    }
}
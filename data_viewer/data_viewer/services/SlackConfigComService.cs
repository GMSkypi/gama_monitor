using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using data_viewer.Constants;
using data_viewer.Model;

namespace data_viewer.services
{
    public class SlackConfigComService : CommunicationService
    {
        public SlackConfigComService(ConfigurationService config) : base(config)
        {
        }

        public async Task<String> getSlackServerURl()
        {
            var uri = new Uri(config.hostName + EndpointConstants.slackURL);
            return await executeRequestSingle<String>(uri, HttpMethod.Get);
        }

        public async Task<bool> setSlackServerUrl(String newSlackUrl)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.slackURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["url"] = newSlackUrl;
            builder.Query = query.ToString();
            var url = builder.Uri;
            return await executeNoresponse(url, HttpMethod.Post);
        }

        public async Task<bool> getSlackServerActiveFlag()
        {
            var uri = new Uri(config.hostName + EndpointConstants.slackActiveURL);
            return await executeRequestSingle<bool>(uri, HttpMethod.Get);
        }
        public async Task<bool> setSlackServerActiveFlag(bool activeFlag)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.slackURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["active"] = activeFlag.ToString();
            builder.Query = query.ToString();
            var url = builder.Uri;
            return await executeRequestSingle<bool>(url, HttpMethod.Post);
        }
        
    }
}
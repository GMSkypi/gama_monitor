using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.Model.Rate;
using Radzen;

namespace data_viewer.services
{
    public class NetComService : CommunicationService
    {
        public NetComService(ConfigurationService config, NotificationService notificationService, HttpClient httpClient) : base(config,notificationService,httpClient)
        {
        }
        public async Task<IEnumerable<NetSample>> GetNetSample(string containerId, DateTime from, DateTime to)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.NetUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[EpAttributeConstants.ContainerId] = containerId;
            query[EpAttributeConstants.DateFrom] = from.ToUniversalTime().ToString(DateTimeFormat);
            query[EpAttributeConstants.DateTo] = to.ToUniversalTime().ToString(DateTimeFormat);
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await ExecuteRequestSingle<NetRecord>(url, HttpMethod.Get);
            return (result != null) ? result.values : new List<NetSample>();
        }

        public async Task<IEnumerable<NetSample>> GetNetSample(string containerId, DateTime from, DateTime to, SampledBy sampledBy)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.NetUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[EpAttributeConstants.ContainerId] = containerId;
            query[EpAttributeConstants.DateFrom] = from.ToUniversalTime().ToString(DateTimeFormat);
            query[EpAttributeConstants.DateTo] = to.ToUniversalTime().ToString(DateTimeFormat);
            query[EpAttributeConstants.SampleRate] = sampledBy.toString();
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await ExecuteRequestSingle<NetRecord>(url, HttpMethod.Get);
            return (result != null) ? result.values : new List<NetSample>();
        }

        public async Task<IEnumerable<NetSample>> GetNetSample(string containerId, DateTime from)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.NetUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[EpAttributeConstants.ContainerId] = containerId;
            query[EpAttributeConstants.DateFrom] = from.ToUniversalTime().ToString(DateTimeFormat);
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await ExecuteRequestSingle<NetRecord>(url, HttpMethod.Get);
            return (result != null) ? result.values : new List<NetSample>();
        }

        public async Task<IEnumerable<NetSample>> GetNetSample(string containerId, DateTime from, SampledBy sampledBy)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.NetUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query[EpAttributeConstants.ContainerId] = containerId;
            query[EpAttributeConstants.DateFrom] = from.ToUniversalTime().ToString(DateTimeFormat);
            query[EpAttributeConstants.SampleRate] = sampledBy.toString();
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await ExecuteRequestSingle<NetRecord>(url, HttpMethod.Get);
            return (result != null) ? result.values : new List<NetSample>();
        }
    }
}
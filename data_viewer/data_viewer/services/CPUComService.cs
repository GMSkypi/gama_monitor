

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
    public class CPUComService : CommunicationService
    {
        public CPUComService(ConfigurationService config, NotificationService notificationService, HttpClient httpClient) : base(config,notificationService,httpClient)
        {
        }

        public async Task<IEnumerable<CpuSample>> getCpuSamples(String containerId, DateTime from, DateTime to)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.cpuURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["containerId"] = containerId;
            query["dateFrom"] = from.ToUniversalTime().ToString(dateTimeFormat);
            query["dateTo"] = to.ToUniversalTime().ToString(dateTimeFormat);
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<CpuRecord>(url, HttpMethod.Get);
            return (result != null) ? result.values : new List<CpuSample>();
        }

        public async Task<IEnumerable<CpuSample>> getCpuSamples(String containerId, DateTime from, DateTime to, SampledBy sampledBy)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.cpuURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["containerId"] = containerId;
            query["dateFrom"] = from.ToUniversalTime().ToString(dateTimeFormat);
            query["dateTo"] = to.ToUniversalTime().ToString(dateTimeFormat);
            query["sampleRate"] = sampledBy.toString();
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<CpuRecord>(url, HttpMethod.Get);
            return (result != null) ? result.values : new List<CpuSample>();
        }

        public async Task<IEnumerable<CpuSample>> getCpuSamples(String containerId, DateTime from)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.cpuURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["containerId"] = containerId;
            query["dateFrom"] = from.ToUniversalTime().ToString(dateTimeFormat);
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<CpuRecord>(url, HttpMethod.Get);
            return (result != null) ? result.values : new List<CpuSample>();
        }

        public async Task<IEnumerable<CpuSample>> getCpuSamples(String containerId, DateTime from, SampledBy sampledBy)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.cpuURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["containerId"] = containerId;
            query["dateFrom"] = from.ToUniversalTime().ToString(dateTimeFormat);
            query["sampleRate"] = sampledBy.toString();
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<CpuRecord>(url, HttpMethod.Get);
            return (result != null) ? result.values : new List<CpuSample>();
        }
    }
}
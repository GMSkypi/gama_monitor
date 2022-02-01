using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using data_viewer.Constants;
using data_viewer.Model;
using data_viewer.Model.Rate;

namespace data_viewer.services
{
    public class MemoryComService : CommunicationService
    {
        public MemoryComService(ConfigurationService config) : base(config)
        {
        }
        public async Task<IEnumerable<MemorySample>> getMemorySample(String containerId, DateTime from, DateTime to)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.memoryURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["containerId"] = containerId;
            query["dateFrom"] = from.ToUniversalTime().ToString(dateTimeFormat);
            query["dateTo"] = to.ToUniversalTime().ToString(dateTimeFormat);
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<MemoryRecord>(url);
            return (result != null) ? result.values : new List<MemorySample>();
        }

        public async Task<IEnumerable<MemorySample>> getMemorySample(String containerId, DateTime from, DateTime to, SampledBy sampledBy)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.memoryURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["containerId"] = containerId;
            query["dateFrom"] = from.ToUniversalTime().ToString(dateTimeFormat);
            query["dateTo"] = to.ToUniversalTime().ToString(dateTimeFormat);
            query["sampleRate"] = sampledBy.toString();
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<MemoryRecord>(url);
            return (result != null) ? result.values : new List<MemorySample>();
        }

        public async Task<IEnumerable<MemorySample>> getMemorySample(String containerId, DateTime from)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.memoryURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["containerId"] = containerId;
            query["dateFrom"] = from.ToUniversalTime().ToString(dateTimeFormat);
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<MemoryRecord>(url);
            return (result != null) ? result.values : new List<MemorySample>();
        }

        public async Task<IEnumerable<MemorySample>> getMemorySample(String containerId, DateTime from, SampledBy sampledBy)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.memoryURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["containerId"] = containerId;
            query["dateFrom"] = from.ToUniversalTime().ToString(dateTimeFormat);
            query["sampleRate"] = sampledBy.toString();
            builder.Query = query.ToString();
            var url = builder.Uri;
            var result =  await executeRequestSingle<MemoryRecord>(url);
            return (result != null) ? result.values : new List<MemorySample>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using data_viewer.Constants;
using data_viewer.Model;

namespace data_viewer.services
{
    public class ContainerComService : CommunicationService
    {
        public ContainerComService(ConfigurationService config) : base(config)
        {
        }
        public async Task<IEnumerable<Container>> getContainers()
        {
            var uri = new Uri(config.hostName + EndpointConstants.containersURL);
            return await executeRequestMultiple<Container>(uri);
        }
        public async Task<Container> getContainer(String id)
        {
            var builder = new UriBuilder(config.hostName + EndpointConstants.containerURL);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["id"] = id;
            builder.Query = query.ToString();
            var url = builder.Uri;
            return await executeRequestSingle<Container>(url);
        }
    }
}
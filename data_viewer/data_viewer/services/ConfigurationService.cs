using System;

namespace data_viewer.services
{
    public class ConfigurationService
    {
        public String hostName { get; }

        public ConfigurationService(String hostName)
        {
            this.hostName = hostName;
        }
    }
}
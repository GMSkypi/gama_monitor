using System;

namespace data_viewer.Constants
{
    public static class EndpointConstants
    {
        public const string containerURL = "/container/";
        public const string containersURL = "/container/containers";
        public const string dashboardURL = "/container/dashboard";
        
        public const string cpuURL = "/cpu/";
        public const string memoryURL = "/memory/";
        public const string ioURL = "/io/";
        public const string netURL = "/net/";
        
        public const string notificationURL = "/notification/";
        public const string notificationsURL = "/notification/notifications";

        public const String slackURL = "/notification/slack_server";
        public const String slackActiveURL = "/notification/slack_server";

        public const String serverAlive = "/testConnection";
    }
}
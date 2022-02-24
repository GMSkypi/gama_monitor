using System;

namespace data_viewer.Constants
{
    public static class EndpointConstants
    {
        public const String containerURL = "/container/";
        public const String containersURL = "/container/containers";
        public const String dashboardURL = "/container/dashboard";
        
        public const String cpuURL = "/cpu/";
        public const String memoryURL = "/memory/";
        public const String ioURL = "/io/";
        public const String netURL = "/net/";
        
        public const String notificationURL = "/notification/";
        public const String notificationsURL = "/notification/notifications";

        public const String slackURL = "/notification/slack_server";
        public const String slackActiveURL = "/notification/slack_server";

        public const String serverAlive = "/testConnection";

        public const String passwordChangeURL = "/user/password";
        public const String usernameChangeURL = "/user/username";
    }
}
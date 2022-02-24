using System;

namespace data_viewer.Constants
{
    public static class EndpointConstants
    {
        public const string ContainerUrl = "/container/";
        public const string ContainersUrl = "/container/containers";
        public const string DashboardUrl = "/container/dashboard";
        
        public const string CpuUrl = "/cpu/";
        public const string MemoryUrl = "/memory/";
        public const string IoUrl = "/io/";
        public const string NetUrl = "/net/";
        
        public const string NotificationUrl = "/notification/";
        public const string NotificationsUrl = "/notification/notifications";

        public const string SlackUrl = "/notification/slack_server";
        public const string SlackActiveUrl = "/notification/slack_server";

        public const string ServerAlive = "/testConnection";

        public const string PasswordChangeUrl = "/user/password";
        public const string UsernameChangeUrl = "/user/username";
    }
}
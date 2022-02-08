using System;

namespace data_viewer.Model.Notification
{
    public class Notification
    {
        public long id { get; set; }
        public String containerId { get; set; }
        public Metrics metricToMonitor { get; set; }
        public Group metricGroup { get; set; }
        public String message { get; set; }
        public long value { get; set; }
        public long overTime { get; set; }

        public long notificationDelay { get; set; }

        public NotificationType type { get; set; }
        public ChangeNotify changeNotify { get; set; }
        public ThresholdNotify thresholdNotify { get; set; }

        public Notification Clone()
        {
            return new Notification
            {
                id = id,
                containerId = containerId,
                metricToMonitor = metricToMonitor,
                metricGroup = metricGroup,
                message = message,
                value = value,
                overTime = overTime,
                notificationDelay = notificationDelay,
                type = type,
                changeNotify = type == NotificationType.CHANGE ? changeNotify : null,
                thresholdNotify = type == NotificationType.THRESHOLD ? thresholdNotify : null,
            };
        }
    }
}
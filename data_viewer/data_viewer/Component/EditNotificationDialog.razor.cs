using System;
using System.Collections.Generic;
using System.Linq;
using data_viewer.Constants;
using data_viewer.Extension;
using data_viewer.Model.Notification;
using data_viewer.services;
using Microsoft.AspNetCore.Components;
using Radzen;
using Group = data_viewer.Model.Notification.Group;

namespace data_viewer.Component
{
    public partial class EditNotificationDialog : ComponentBase, IDisposable
    {
         [Parameter]
         public Notification notification { get; set; }
    
        protected Notification notificationCopy { get; set; }
        
        [Inject]
        public DialogService DialogService { get; set; }
        
        [Inject] private NotificationComService notificationComService { get; set; }
        
        List<EnumExtension<Group>> enumGroups = new ();
        List<EnumExtension<Metrics>> enumMetrics = new ();
        List<EnumExtension<NotificationType>> enumNotificationType = new ();
        List<EnumExtension<Threshold>> enumThresholds = new ();
        List<EnumExtension<Trigger>> enumTriggers = new ();

        protected override void OnInitialized()
        {
            enumGroups = EnumExtension<Group>.getAllEnumExtension();
            enumNotificationType = EnumExtension<NotificationType>.getAllEnumExtension();
            enumThresholds = EnumExtension<Threshold>.getAllEnumExtension();
            enumTriggers = EnumExtension<Trigger>.getAllEnumExtension();
            loadMetrics(notification.metricGroup);
            if (notification.type == NotificationType.CHANGE && notification.changeNotify == null)
                notification.changeNotify = new ChangeNotify();

            else if (notification.type == NotificationType.THRESHOLD && notification.thresholdNotify == null)
                notification.thresholdNotify = new ThresholdNotify();
        }

        protected void ReloadMetrics()
        {
            loadMetrics(notificationCopy.metricGroup);
            notificationCopy.metricToMonitor = enumMetrics.First().EnumValue;
        }

        protected void ReloadNotifType()
        {
            if (notificationCopy.type == NotificationType.CHANGE)
            {
                notificationCopy.changeNotify = new ChangeNotify();
                notificationCopy.thresholdNotify = null;
            }
            else
            {
                notificationCopy.thresholdNotify = new ThresholdNotify();
                notificationCopy.changeNotify = null;
            }
        }

        public void loadMetrics(Group group)
        {
            switch (group)
            {
                case Group.CPU :
                    enumMetrics = EnumExtension<Metrics>.getEnumExtension(EnumMetricGroups.CpuMetricsList);
                    break;
                case Group.MEMORY :
                    enumMetrics = EnumExtension<Metrics>.getEnumExtension(EnumMetricGroups.MemoryMetricsList);
                    break;
                case Group.NET :
                    enumMetrics = EnumExtension<Metrics>.getEnumExtension(EnumMetricGroups.NetMetricsList);
                    break;
                case Group.IO :
                    enumMetrics = EnumExtension<Metrics>.getEnumExtension(EnumMetricGroups.IoMetricsList);
                    break;
            }
        }

        public void Dispose()
        {
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            notificationCopy = notification.Clone();
        }
        protected void ValidSubmit()
        {
            notification.id = notificationCopy.id;
            notification.message = notificationCopy.message;
            notification.type = notificationCopy.type;
            notification.value = notificationCopy.value;
            notification.changeNotify = notificationCopy.changeNotify;
            notification.containerId = notificationCopy.containerId;
            notification.metricGroup = notificationCopy.metricGroup;
            notification.notificationDelay = notificationCopy.notificationDelay;
            notification.overTime = notificationCopy.overTime;
            notification.thresholdNotify = notificationCopy.thresholdNotify;
            notification.metricToMonitor = notificationCopy.metricToMonitor;
            DialogService.Close(true);
        }
    }
}
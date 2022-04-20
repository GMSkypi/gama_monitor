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
        [Parameter] public Notification notification { get; set; }
        [Inject] public DialogService dialogService { get; set; }
        private Notification notificationCopy { get; set; }
        
        private List<EnumExtension<Group>> _enumGroups = new();
        private List<EnumExtension<Metrics>> _enumMetrics = new();
        private List<EnumExtension<NotificationType>> _enumNotificationType = new();
        private List<EnumExtension<Threshold>> _enumThresholds = new();
        private List<EnumExtension<Trigger>> _enumTriggers = new();

        protected override void OnInitialized()
        {
            _enumGroups = EnumExtension<Group>.GetAllEnumExtension();
            _enumNotificationType = EnumExtension<NotificationType>.GetAllEnumExtension();
            _enumThresholds = EnumExtension<Threshold>.GetAllEnumExtension();
            _enumTriggers = EnumExtension<Trigger>.GetAllEnumExtension();
            LoadMetrics(notification.metricGroup);
            if (notification.type == NotificationType.CHANGE && notification.changeNotify == null)
                notification.changeNotify = new ChangeNotify();

            else if (notification.type == NotificationType.THRESHOLD && notification.thresholdNotify == null)
                notification.thresholdNotify = new ThresholdNotify();
        }

        private void ReloadMetrics()
        {
            LoadMetrics(notificationCopy.metricGroup);
            notificationCopy.metricToMonitor = _enumMetrics.First().enumValue;
        }

        private void ReloadNotificationType()
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

        private void LoadMetrics(Group group)
        {
            _enumMetrics = @group switch
            {
                Group.CPU => EnumExtension<Metrics>.GetEnumExtension(EnumMetricGroups.CpuMetricsList),
                Group.MEMORY => EnumExtension<Metrics>.GetEnumExtension(EnumMetricGroups.MemoryMetricsList),
                Group.NET => EnumExtension<Metrics>.GetEnumExtension(EnumMetricGroups.NetMetricsList),
                Group.IO => EnumExtension<Metrics>.GetEnumExtension(EnumMetricGroups.IoMetricsList),
                _ => _enumMetrics
            };
        }

        public void Dispose()
        {
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            notificationCopy = notification.Clone();
        }

        private void ValidSubmit()
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
            dialogService.Close(true);
        }
    }
}
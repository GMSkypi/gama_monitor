package docker_monitor.DM_app.process.object;


import docker_monitor.DM_app.constants.Group;
import docker_monitor.DM_app.constants.Metrics;

public class Notification {
    long id;
    String containerId;
    Metrics metricToMonitor;
    Group metricGroup;
    String message;
    long value;
    long overTime;

    long notificationDelay;

    NotificationType type;
    ChangeNotify changeNotify;
    ThresholdNotify thresholdNotify;

    public Notification(String containerId, Metrics valueToMonitor,Group group, String message, long value, long overTime, ThresholdNotify thresholdNotify, long delay) {
        this.containerId = containerId;
        this.metricToMonitor = valueToMonitor;
        this.message = message;
        this.value = value;
        this.overTime = overTime;
        this.thresholdNotify = thresholdNotify;
        type = NotificationType.THRESHOLD;
        this.metricGroup = group;
        this.notificationDelay = delay;
    }
    public Notification(){}

    public Notification(String containerId, Metrics valueToMonitor, Group group, String message, long value, long overTime, ChangeNotify changeNotify, long delay) {
        this.containerId = containerId;
        this.metricToMonitor = valueToMonitor;
        this.message = message;
        this.value = value;
        this.overTime = overTime;
        this.changeNotify = changeNotify;
        type = NotificationType.CHANGE;
        this.metricGroup = group;
        this.notificationDelay = delay;
    }
    public Notification(Notification notif) {
        this.containerId = notif.containerId;
        this.metricToMonitor = notif.metricToMonitor;
        this.message = notif.message;
        this.value = notif.value;
        this.overTime = notif.overTime;
        this.changeNotify = notif.changeNotify;
        this.type = notif.type;
        this.thresholdNotify = notif.thresholdNotify;
        this.id = notif.id;
        this.metricGroup = notif.metricGroup;
        this.notificationDelay = notif.notificationDelay;
    }

    public String getContainerId() {
        return containerId;
    }

    public void setContainerId(String containerId) {
        this.containerId = containerId;
    }

    public Metrics getMetricToMonitor() {
        return metricToMonitor;
    }

    public void setMetricToMonitor(Metrics metricToMonitor) {
        this.metricToMonitor = metricToMonitor;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public long getValue() {
        return value;
    }

    public void setValue(long value) {
        this.value = value;
    }

    public long getOverTime() {
        return overTime;
    }

    public void setOverTime(long overTime) {
        this.overTime = overTime;
    }

    public NotificationType getType() {
        return type;
    }

    public void setType(NotificationType type) {
        this.type = type;
    }

    public ChangeNotify getChangeNotify() {
        return changeNotify;
    }

    public void setChangeNotify(ChangeNotify changeNotify) {
        this.changeNotify = changeNotify;
    }

    public ThresholdNotify getThresholdNotify() {
        return thresholdNotify;
    }

    public void setThresholdNotify(ThresholdNotify thresholdNotify) {
        this.thresholdNotify = thresholdNotify;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public Group getMetricGroup() {
        return metricGroup;
    }

    public void setMetricGroup(Group metricGroup) {
        this.metricGroup = metricGroup;
    }

    public long getNotificationDelay() {
        return notificationDelay;
    }

    public void setNotificationDelay(long notificationDelay) {
        this.notificationDelay = notificationDelay;
    }
}

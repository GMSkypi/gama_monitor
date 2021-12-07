package docker_monitor.DM_app.process.object;


import com.fasterxml.jackson.annotation.JsonView;

public class Notification {
    String containerId;
    String valueToMonitor;
    String message;
    long value;
    long overTime;

    NotificationType type;
    ChangeNotify changeNotify;
    ThresholdNotify thresholdNotify;

    public Notification(String containerId, String valueToMonitor, String message, long value, long overTime, ThresholdNotify thresholdNotify) {
        this.containerId = containerId;
        this.valueToMonitor = valueToMonitor;
        this.message = message;
        this.value = value;
        this.overTime = overTime;
        this.thresholdNotify = thresholdNotify;
        type = NotificationType.THRESHOLD;
    }
    public Notification(){}

    public Notification(String containerId, String valueToMonitor, String message, long value, long overTime, ChangeNotify changeNotify) {
        this.containerId = containerId;
        this.valueToMonitor = valueToMonitor;
        this.message = message;
        this.value = value;
        this.overTime = overTime;
        this.changeNotify = changeNotify;
        type = NotificationType.CHANGE;
    }
    public Notification(Notification notif) {
        this.containerId = notif.containerId;
        this.valueToMonitor = notif.valueToMonitor;
        this.message = notif.message;
        this.value = notif.value;
        this.overTime = notif.overTime;
        this.changeNotify = notif.changeNotify;
        this.type = notif.type;
        this.thresholdNotify = notif.thresholdNotify;
    }

    public String getContainerId() {
        return containerId;
    }

    public void setContainerId(String containerId) {
        this.containerId = containerId;
    }

    public String getValueToMonitor() {
        return valueToMonitor;
    }

    public void setValueToMonitor(String valueToMonitor) {
        this.valueToMonitor = valueToMonitor;
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
}

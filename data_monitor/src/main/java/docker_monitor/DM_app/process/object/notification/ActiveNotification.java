package docker_monitor.DM_app.process.object.notification;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import java.time.Instant;

@JsonIgnoreProperties({"lastCheckTime"})
public class ActiveNotification {
    Instant lastCheckTime;
    Instant lastNotificationTime;
    Notification notification;

    public ActiveNotification(Notification notification){
        this.notification = notification;
        lastCheckTime = Instant.ofEpochMilli(0);
        lastNotificationTime  = Instant.ofEpochMilli(0);
    }

    public Instant getLastCheckTime() {
        return lastCheckTime;
    }

    public void setLastCheckTime(Instant lastCheckTime) {
        this.lastCheckTime = lastCheckTime;
    }

    public Notification getNotification() {
        return notification;
    }

    public void setNotification(Notification notification) {
        this.notification = notification;
    }

    public Instant getLastNotificationTime() {
        return lastNotificationTime;
    }

    public void setLastNotificationTime(Instant lastNotificationTime) {
        this.lastNotificationTime = lastNotificationTime;
    }
}

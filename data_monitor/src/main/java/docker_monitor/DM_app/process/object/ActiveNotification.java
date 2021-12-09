package docker_monitor.DM_app.process.object;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import java.util.Date;

@JsonIgnoreProperties({"lastCheckTime"})
public class ActiveNotification {
    Date lastCheckTime;
    Notification notification;

    public ActiveNotification(Notification notification){
        this.notification = notification;
        lastCheckTime = new Date();
    }

    public Date getLastCheckTime() {
        return lastCheckTime;
    }

    public void setLastCheckTime(Date lastCheckTime) {
        this.lastCheckTime = lastCheckTime;
    }

    public Notification getNotification() {
        return notification;
    }

    public void setNotification(Notification notification) {
        this.notification = notification;
    }
}

package docker_monitor.DM_app.process.object;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import java.util.Date;

@JsonIgnoreProperties({"lastCheckTime"})
public class ActiveNotification extends Notification {
    Date lastCheckTime;

    public ActiveNotification(Notification notification){
        super(notification);
        lastCheckTime = new Date();
    }

    public void setLastCheckTime(Date lastCheckTime) {
        this.lastCheckTime = lastCheckTime;
    }
}

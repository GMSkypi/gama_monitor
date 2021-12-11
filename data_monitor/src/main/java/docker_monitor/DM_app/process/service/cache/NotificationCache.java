package docker_monitor.DM_app.process.service.cache;

import docker_monitor.DM_app.process.object.ActiveNotification;
import docker_monitor.DM_app.process.object.Notification;
import docker_monitor.DM_app.process.service.NotificationSerialization;
import org.springframework.stereotype.Component;

import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

@Component
public class NotificationCache {

    NotificationSerialization serialization;

    List<ActiveNotification> notifications;

    public void addNotification(Notification newNotification){
        if(notifications.isEmpty())
            newNotification.setId(1);
        else
            newNotification.setId(notifications.get(notifications.size() - 1).getNotification().getId() + 1);
        notifications.add(new ActiveNotification(newNotification));

        notifications.sort(Comparator.comparing(o -> o.getNotification().getContainerId()));
        serialization.serialize((notifications.stream().map(ActiveNotification::getNotification).collect(Collectors.toList())));


    }
    public void removeNotification(ActiveNotification toBeRemoved){
        notifications.remove(toBeRemoved);
        serialization.serialize((notifications.stream().map(ActiveNotification::getNotification).collect(Collectors.toList())));
    }

    public NotificationCache(NotificationSerialization serialization){
        this.serialization = serialization;
        List<Notification> notInitializedNotifications = serialization.loadObjects();
        this.notifications = notInitializedNotifications.stream().map(ActiveNotification::new).collect(Collectors.toList());
    }

    public List<ActiveNotification> getNotifications() {
        return notifications;
    }

    public void setNotifications(List<ActiveNotification> notifications) {
        this.notifications = notifications;
    }

    private boolean checkNotificationMetric(Notification newNotification){
        return false;
    }

}

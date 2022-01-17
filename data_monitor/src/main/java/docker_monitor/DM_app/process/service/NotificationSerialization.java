package docker_monitor.DM_app.process.service;

import docker_monitor.DM_app.process.object.notification.Notification;

import java.util.List;

public interface NotificationSerialization {
    boolean serialize(Iterable<Notification> notifications);
    List<Notification> loadObjects();
}

package docker_monitor.DM_app.process.service;

import docker_monitor.DM_app.process.object.notification.Notification;

public interface MessageNotification {
    void notifyObservers(Notification notification, long value);
}

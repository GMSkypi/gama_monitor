package docker_monitor.DM_app.process.service;

import docker_monitor.DM_app.process.object.Notification;

public interface MessageNotifConvertor {
    String convertNotificationToMessage(Notification notification, long value);
}

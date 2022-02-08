package docker_monitor.DM_app.process.service.data_service;

import docker_monitor.DM_app.process.object.notification.ActiveNotification;
import docker_monitor.DM_app.process.object.notification.Notification;

import java.util.List;
import java.util.Objects;
import java.util.Optional;

public interface NotificationDataService {
    void deleteNotification(long id);
    Notification getNotification(long id);
    List<Notification> getNotifications();
    Notification createNotification(Notification notification);
    Notification updateNotification(Notification newNotification);
}

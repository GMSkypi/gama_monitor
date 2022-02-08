package docker_monitor.DM_app.process.service.data_service;

import docker_monitor.DM_app.process.object.notification.ActiveNotification;
import docker_monitor.DM_app.process.object.notification.Notification;
import docker_monitor.DM_app.process.service.cache.NotificationCache;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Objects;
import java.util.Optional;

@Service
public class NotificationDataServiceImp implements NotificationDataService{
    @Autowired
    NotificationCache cache;

    public void deleteNotification(long id){
        List<ActiveNotification> active = cache.getNotifications();
        Optional<ActiveNotification> notif = active.stream().filter(a -> Objects.equals(a.getNotification().getId(), id)).findFirst();
        notif.ifPresent(activeNotification -> cache.removeNotification(activeNotification));
    }
    public Notification getNotification(long id){
        return cache.getNotifications()
                .stream()
                .filter(a -> Objects.equals(a.getNotification().getId(), id))
                .findFirst()
                .map(ActiveNotification::getNotification)
                .orElse(null);
    }
    public List<Notification> getNotifications(){
        return cache.getNotifications()
                .stream()
                .map(ActiveNotification::getNotification)
                .toList();
    }
    public Notification createNotification(Notification notification){
        return cache.addNotification(notification);
    }
    public Notification updateNotification(Notification newNotification){
        return cache.updateNotification(newNotification);
    }
}

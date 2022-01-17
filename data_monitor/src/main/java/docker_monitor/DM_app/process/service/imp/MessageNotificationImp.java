package docker_monitor.DM_app.process.service.imp;


import docker_monitor.DM_app.process.notification_message_handler.NotificationObservers;
import docker_monitor.DM_app.process.object.Notification;
import docker_monitor.DM_app.process.service.MessageNotifConvertor;
import docker_monitor.DM_app.process.service.MessageNotification;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MessageNotificationImp implements MessageNotification {

    @Autowired
    List<NotificationObservers> observers;

    @Autowired
    MessageNotifConvertor convertor;

    @Override
    public void notifyObservers(Notification notification, long value){
        String convertedNotification = convertor.convertNotificationToMessage(notification,value);
        observers.forEach(observer -> observer.update(convertedNotification));
    }
}

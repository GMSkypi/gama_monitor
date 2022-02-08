package docker_monitor.DM_app.process.service.imp;

import docker_monitor.DM_app.process.object.notification.Notification;
import docker_monitor.DM_app.process.service.MessageNotifConvertor;
import org.springframework.stereotype.Service;

@Service
public class MessageNotifConvertorImp implements MessageNotifConvertor {
    @Override
    public String convertNotificationToMessage(Notification notification, long value){
        String calculation = switch (notification.getType()){
            case THRESHOLD -> "Captured " + notification.getThresholdNotify().getThreshold() + " value: " +
                    value + " is " + notification.getThresholdNotify().getTrigger() + " declared: " +
                    notification.getValue();
            case CHANGE -> "Captured average value difference is: " + Math.abs(value) + " and it is " +
                    notification.getChangeNotify().getTrigger() + " declared value: " +
                    notification.getValue();
        };
        String result = "*Active docker notification WARNING*" + "\n" +
                "*Container:* " + notification.getContainerId() + "\n" +
                "*Metric:* " + notification.getMetricToMonitor() + "\n" +
                "*Metric group:* " + notification.getMetricGroup() + "\n" +
                "*Notification type:* " + notification.getType() + "\n" +
                "*Details:*" + "\n" +
                calculation + "\n" +
                "*Message:*" + "\n" +
                notification.getMessage() + "\n";
        return result;
    }
}

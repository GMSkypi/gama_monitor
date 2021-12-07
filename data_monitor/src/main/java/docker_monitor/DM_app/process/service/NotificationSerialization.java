package docker_monitor.DM_app.process.service;

import docker_monitor.DM_app.process.object.Notification;

import java.util.ArrayList;

public interface NotificationSerialization {
    boolean serialize(Iterable<Notification> notifications);
    ArrayList<Notification> loadObjects();
}

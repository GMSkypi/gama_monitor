package docker_monitor.DM_app.web.controllers;

import docker_monitor.DM_app.process.object.notification.Notification;
import docker_monitor.DM_app.process.service.DTOConversion;
import docker_monitor.DM_app.process.service.cache.NotificationCache;
import docker_monitor.DM_app.process.service.data_service.NotificationDataService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.env.Environment;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@CrossOrigin
@RestController
@RequestMapping("/notification")
@Validated
public class MessageNotificationController {

    @Autowired
    DTOConversion conversion;

    @Autowired
    NotificationDataService notificationService;

    @Autowired
    private Environment env;


    @DeleteMapping(value = "/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteNotification(@PathVariable long id){
        notificationService.deleteNotification(id);
    }
    @GetMapping(value = "/{id}")
    @ResponseStatus(HttpStatus.OK)
    public Notification getNotification(@PathVariable long id){
        return notificationService.getNotification(id);
    }
    @GetMapping(value = "/notifications")
    @ResponseStatus(HttpStatus.OK)
    public List<Notification> getNotifications(){
        return notificationService.getNotifications();
    }

    @PostMapping(value = "/")
    @ResponseStatus(HttpStatus.CREATED)
    public Notification createNotification(
            @RequestBody Notification notification){
        return notificationService.createNotification(notification);
    }
    @PatchMapping(value = "/")
    @ResponseStatus(HttpStatus.OK)
    public Notification updateNotification(
            @RequestBody Notification notification){
        return notificationService.updateNotification(notification);
    }
    @PostMapping(value = "/slack_server" , params = {"url"})
    @ResponseStatus(HttpStatus.OK)
    public void setSlackServerURl(
            @RequestParam("url") String url){
        // TODO not implemented
    }
    @GetMapping(value = "/slack_server")
    @ResponseStatus(HttpStatus.OK)
    public String getSlackServerURl(){
        return env.getProperty("slack.webhook");
    }
}

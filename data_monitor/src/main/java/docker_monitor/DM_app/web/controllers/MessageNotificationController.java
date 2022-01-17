package docker_monitor.DM_app.web.controllers;

import docker_monitor.DM_app.web.dto.notification_dto.NotificationDTO;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/notification")
@Validated
public class MessageNotificationController {

    @DeleteMapping(value = "/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteNotification(@PathVariable String id){

    }
    @GetMapping(value = "/{id}")
    @ResponseStatus(HttpStatus.OK)
    public NotificationDTO getNotification(@PathVariable String id){
        return null;
    }
    @GetMapping(value = "/notifications")
    @ResponseStatus(HttpStatus.OK)
    public List<NotificationDTO> getNotifications(){
        return null;
    }

    @PostMapping(value = "/")
    @ResponseStatus(HttpStatus.CREATED)
    public NotificationDTO createNotification(
            @RequestBody NotificationDTO notification){
        return null;
    }
}

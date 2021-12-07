package docker_monitor.DM_app.web.controllers;


import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.repository.ContainerRepository;
import docker_monitor.DM_app.process.object.*;
import docker_monitor.DM_app.process.service.JSONNotifSerialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;

@RestController
@RequestMapping("/")
@Validated
public class TestController {

    @Autowired
    ContainerRepository containerRepository;

    @Autowired
    JSONNotifSerialization serialization;

    @GetMapping(value = "private")
    @PreAuthorize("hasAuthority('USER')")
    String privateAccess() {
        return "private test success";
    }
    @GetMapping(value = "private/admin")
    @PreAuthorize("hasAuthority('ADMIN')")
    String privateAccessAdmin() {
        return "private admin test success";
    }
    @GetMapping(value = "public2")
    Iterable<Container> publicAccess() {
        ArrayList<Notification> notif = new ArrayList<>();
        notif.add(new ActiveNotification(new Notification("docker","CPUACC","message",10,1,new ThresholdNotify(Trigger.ABOVE, Threshold.AVERAGE))));
        notif.add(new Notification("docker","CPULOAD","message",10,1,new ChangeNotify(Trigger.ABOVE,10)));
        serialization.serialize(notif);
        return containerRepository.findAll();
    }
    @GetMapping(value = "public")
    ArrayList<Notification> loadObjects(){
        return serialization.loadObjects();
    }

}

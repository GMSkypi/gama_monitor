package docker_monitor.DM_app.web.controllers;


import docker_monitor.DM_app.constants.Group;
import docker_monitor.DM_app.constants.Metrics;
import docker_monitor.DM_app.process.database.db_mapper.QuestDBDataMapper;
import docker_monitor.DM_app.process.database.db_source.DataSource;
import docker_monitor.DM_app.process.database.entities.Cpu;
import docker_monitor.DM_app.process.database.repository.CpuRepository;
import docker_monitor.DM_app.process.object.notification.*;
import docker_monitor.DM_app.process.service.MessageNotification;
import docker_monitor.DM_app.process.service.cache.NotificationCache;
import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.repository.ContainerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.stream.Collectors;

@CrossOrigin
@RestController
@RequestMapping("/")
@Validated
public class TestController {

    @Autowired
    private DataSource datasource;


    @GetMapping(value = "testConnection")
    boolean connectionAlive(){
        return datasource.connectionAlive();
    }

    @GetMapping(value = "privatecontent")
    String privateAccessContent() {
        return "Success";
    }

}

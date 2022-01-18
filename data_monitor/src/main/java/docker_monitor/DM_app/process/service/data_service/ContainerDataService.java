package docker_monitor.DM_app.process.service.data_service;

import docker_monitor.DM_app.process.database.entities.Container;

import java.util.List;

public interface ContainerDataService {
    List<Container> getAllContainers();
    Container getContainerById(String id);
}

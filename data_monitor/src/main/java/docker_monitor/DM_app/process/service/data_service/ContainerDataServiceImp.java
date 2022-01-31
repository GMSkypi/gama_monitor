package docker_monitor.DM_app.process.service.data_service;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.repository.ContainerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.util.List;

@Service
public class ContainerDataServiceImp implements ContainerDataService {

    @Autowired
    ContainerRepository containerRepository;

    public List<Container> getAllContainers(){
        return containerRepository.getContainersWithLastRecord();
    }
    public Container getContainerById(String id){
        return containerRepository.findBy(id).orElse(null);
    }
}

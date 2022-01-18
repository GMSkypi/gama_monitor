package docker_monitor.DM_app.web.controllers;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.service.data_service.ContainerDataService;
import docker_monitor.DM_app.process.service.DTOConversion;
import docker_monitor.DM_app.web.dto.ContainerDTO;
import docker_monitor.DM_app.web.dto.DashboardInfoDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/container")
@Validated
public class ContainerController {

    @Autowired
    DTOConversion conversion;

    @Autowired
    ContainerDataService containerService;

    @GetMapping(value = "/{id}")
    @ResponseStatus(HttpStatus.OK)
    public ContainerDTO getContainer(@PathVariable String id){
        Container container = containerService.getContainerById(id);
        return conversion.convertToContainerDTO(container);
    }
    @GetMapping(value = "/containers")
    @ResponseStatus(HttpStatus.OK)
    public List<ContainerDTO> getContainers(){
        List<Container> containers = containerService.getAllContainers();
        return conversion.convertToContainerDTO(containers);
    }
    @GetMapping(value = "/dashboard")
    @ResponseStatus(HttpStatus.OK)
    public List<DashboardInfoDTO> getDashboard(){
        // TODO dashboard
        return null;
    }
}

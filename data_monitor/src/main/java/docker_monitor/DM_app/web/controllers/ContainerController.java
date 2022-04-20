package docker_monitor.DM_app.web.controllers;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.service.data_service.ContainerDataService;
import docker_monitor.DM_app.process.service.DTOConversion;
import docker_monitor.DM_app.web.dto.ContainerDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.time.Instant;
import java.util.List;

@CrossOrigin
@RestController
@RequestMapping("/container")
@Validated
public class ContainerController {

    @Autowired
    DTOConversion conversion;

    @Autowired
    ContainerDataService containerService;

    @GetMapping(value = "/", params = {"id"})
    @ResponseStatus(HttpStatus.OK)
    public ContainerDTO getContainer(@RequestParam("id") String id){
        Container container = containerService.getContainerById(id);
        return conversion.convertToContainerDTO(container);
    }
    @GetMapping(value = "/containers")
    @ResponseStatus(HttpStatus.OK)
    public List<ContainerDTO> getContainers(){
        List<Container> containers = containerService.getAllContainers();
        return conversion.convertToContainerDTO(containers);
    }
    @DeleteMapping(value = "/", params = {"id"})
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteContainer(@RequestParam("id") String id){
        containerService.deleteContainer(id);
    }
}

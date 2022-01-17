package docker_monitor.DM_app.web.controllers;

import docker_monitor.DM_app.web.dto.ContainerDTO;
import docker_monitor.DM_app.web.dto.DashboardInfoDTO;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/container")
@Validated
public class ContainerController {

    @GetMapping(value = "/{id}")
    @ResponseStatus(HttpStatus.OK)
    public ContainerDTO getContainer(@PathVariable String id){
        return null;
    }
    @GetMapping(value = "/containers")
    @ResponseStatus(HttpStatus.OK)
    public List<ContainerDTO> getContainers(){
        return null;
    }
    @GetMapping(value = "/dashboard")
    @ResponseStatus(HttpStatus.OK)
    public List<DashboardInfoDTO> getDashboard(){
        return null;
    }
}

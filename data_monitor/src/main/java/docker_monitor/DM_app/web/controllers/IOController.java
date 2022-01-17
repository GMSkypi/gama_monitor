package docker_monitor.DM_app.web.controllers;


import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.web.dto.IODTO;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.time.Instant;

@RestController
@RequestMapping("/io")
@Validated
public class IOController {

    @GetMapping(value = "/{containerId}")
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIOMet(@PathVariable String containerId){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "dateTo"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIOMetWFDate(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "dateTo", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIOMetWFDateWSample(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo,
            @RequestParam("sampleRate") SampledBy sampleRate){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIDMetWDate(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIOMetWDateWSample(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("sampleRate") SampledBy sampleRate){
        return null;
    }
}

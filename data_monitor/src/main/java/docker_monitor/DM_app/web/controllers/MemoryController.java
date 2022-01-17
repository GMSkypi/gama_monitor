package docker_monitor.DM_app.web.controllers;


import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.web.dto.MemoryDTO;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.time.Instant;

@RestController
@RequestMapping("/memory")
@Validated
public class MemoryController {

    @GetMapping(value = "/{containerId}")
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMet(@PathVariable String containerId){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "dateTo"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWFDate(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "dateTo", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWFDateWSample(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo,
            @RequestParam("sampleRate") SampledBy sampleRate){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWDate(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWDateWSample(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("sampleRate") SampledBy sampleRate){
        return null;
    }
}

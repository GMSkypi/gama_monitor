package docker_monitor.DM_app.web.controllers;

import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.web.dto.CpuDTO;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.time.Instant;

@RestController
@RequestMapping("/cpu")
@Validated
public class CpuController {

    @GetMapping(value = "/{containerId}")
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMet(@PathVariable String containerId){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "dateTo"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMetWFDate(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "dateTo", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMetWFDateWSample(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo,
            @RequestParam("sampleRate") SampledBy sampleRate){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMetWDate(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom){
        return null;
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMetWDateWSample(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("sampleRate") SampledBy sampleRate){
        return null;
    }
}

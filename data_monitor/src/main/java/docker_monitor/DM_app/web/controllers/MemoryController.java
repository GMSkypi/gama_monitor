package docker_monitor.DM_app.web.controllers;


import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.IO;
import docker_monitor.DM_app.process.database.entities.Memory;
import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.process.object.MetricPair;
import docker_monitor.DM_app.process.service.DTOConversion;
import docker_monitor.DM_app.process.service.data_service.MemoryDataService;
import docker_monitor.DM_app.web.dto.MemoryDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.time.Instant;

@RestController
@RequestMapping("/memory")
@Validated
public class MemoryController {
    @Autowired
    DTOConversion conversion;

    @Autowired
    MemoryDataService memoryService;

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
        MetricPair<Container, Memory> pair = memoryService.getMemoryMetrics(containerId,dateFrom,dateTo);
        return conversion.convertToMemDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "dateTo", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWFDateWSample(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, Memory> pair = memoryService.getMemoryMetrics(containerId,dateFrom,dateTo,sampleRate);
        return conversion.convertToMemDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWDate(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom){
        MetricPair<Container, Memory> pair = memoryService.getMemoryMetrics(containerId,dateFrom);
        return conversion.convertToMemDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/{containerId}", params = {"dateFrom", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWDateWSample(
            @PathVariable String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, Memory> pair = memoryService.getMemoryMetrics(containerId,dateFrom,sampleRate);
        return conversion.convertToMemDTO(pair.getMetrics(),pair.getContainer());
    }
}

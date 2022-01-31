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

@CrossOrigin
@RestController
@RequestMapping("/memory")
@Validated
public class MemoryController {
    @Autowired
    DTOConversion conversion;

    @Autowired
    MemoryDataService memoryService;

    @GetMapping(value = "/", params = {"containerId"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMet(@RequestParam("containerId") String containerId){
        return null;
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "dateTo"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWFDate(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo){
        MetricPair<Container, Memory> pair = memoryService.getMemoryMetrics(containerId,dateFrom,dateTo);
        return conversion.convertToMemDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "dateTo", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWFDateWSample(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, Memory> pair = memoryService.getMemoryMetrics(containerId,dateFrom,dateTo,sampleRate);
        return conversion.convertToMemDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWDate(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom){
        MetricPair<Container, Memory> pair = memoryService.getMemoryMetrics(containerId,dateFrom);
        return conversion.convertToMemDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public MemoryDTO getMemMetWDateWSample(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, Memory> pair = memoryService.getMemoryMetrics(containerId,dateFrom,sampleRate);
        return conversion.convertToMemDTO(pair.getMetrics(),pair.getContainer());
    }
}

package docker_monitor.DM_app.web.controllers;


import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.IO;
import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.process.object.MetricPair;
import docker_monitor.DM_app.process.service.DTOConversion;
import docker_monitor.DM_app.process.service.data_service.IODataService;
import docker_monitor.DM_app.web.dto.IODTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.time.Instant;

@CrossOrigin
@RestController
@RequestMapping("/io")
@Validated
public class IOController {

    @Autowired
    DTOConversion conversion;

    @Autowired
    IODataService ioService;

    @GetMapping(value = "/", params = {"containerId"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIOMet(@RequestParam("containerId") String containerId){
        return null;
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "dateTo"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIOMetWFDate(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo){
        MetricPair<Container, IO> pair = ioService.getIOMetrics(containerId,dateFrom,dateTo);
        return conversion.convertToIODTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "dateTo", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIOMetWFDateWSample(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, IO> pair = ioService.getIOMetrics(containerId,dateFrom,dateTo,sampleRate);
        return conversion.convertToIODTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIDMetWDate(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom){
        MetricPair<Container, IO> pair = ioService.getIOMetrics(containerId,dateFrom);
        return conversion.convertToIODTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public IODTO getIOMetWDateWSample(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, IO> pair = ioService.getIOMetrics(containerId,dateFrom,sampleRate);
        return conversion.convertToIODTO(pair.getMetrics(),pair.getContainer());
    }
}

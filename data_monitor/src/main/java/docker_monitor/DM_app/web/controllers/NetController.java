package docker_monitor.DM_app.web.controllers;


import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.Memory;
import docker_monitor.DM_app.process.database.entities.Net;
import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.process.object.MetricPair;
import docker_monitor.DM_app.process.service.DTOConversion;
import docker_monitor.DM_app.process.service.data_service.NetDataService;
import docker_monitor.DM_app.web.dto.NetDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.time.Instant;

@CrossOrigin
@RestController
@RequestMapping("/net")
@Validated
public class NetController {
    @Autowired
    DTOConversion conversion;

    @Autowired
    NetDataService netService;

    @GetMapping(value = "/", params = {"containerId"})
    @ResponseStatus(HttpStatus.OK)
    public NetDTO getNetMet(@RequestParam("containerId") String containerId){
        return null;
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "dateTo"})
    @ResponseStatus(HttpStatus.OK)
    public NetDTO getNetMetWFDate(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo){
        MetricPair<Container, Net> pair = netService.getNetMetrics(containerId,dateFrom,dateTo);
        return conversion.convertToNetDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "dateTo", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public NetDTO getNetMetWFDateWSample(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, Net> pair = netService.getNetMetrics(containerId,dateFrom,dateTo,sampleRate);
        return conversion.convertToNetDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom"})
    @ResponseStatus(HttpStatus.OK)
    public NetDTO getNetMetWDate(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom){
        MetricPair<Container, Net> pair = netService.getNetMetrics(containerId,dateFrom);
        return conversion.convertToNetDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public NetDTO getNetMetWDateWSample(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, Net> pair = netService.getNetMetrics(containerId,dateFrom,sampleRate);
        return conversion.convertToNetDTO(pair.getMetrics(),pair.getContainer());
    }
}

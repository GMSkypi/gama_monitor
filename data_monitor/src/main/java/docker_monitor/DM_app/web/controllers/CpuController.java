package docker_monitor.DM_app.web.controllers;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.Cpu;
import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.process.object.MetricPair;
import docker_monitor.DM_app.process.service.data_service.CpuDataService;
import docker_monitor.DM_app.process.service.DTOConversion;
import docker_monitor.DM_app.web.dto.CpuDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.time.Instant;

@CrossOrigin
@RestController
@RequestMapping("/cpu")
@Validated
public class CpuController {

    @Autowired
    DTOConversion conversion;

    @Autowired
    CpuDataService cpuService;

    @GetMapping(value = "/",  params = {"containerId"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMet(@RequestParam("containerId") String containerId){

        return null;
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "dateTo"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMetWFDate(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo){
        MetricPair<Container, Cpu> pair = cpuService.getCpuMetrics(containerId,dateFrom,dateTo);
        return conversion.convertToCpuDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "dateTo", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMetWFDateWSample(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("dateTo") Instant dateTo,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, Cpu> pair = cpuService.getCpuMetrics(containerId,dateFrom,dateTo,sampleRate);
        return conversion.convertToCpuDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMetWDate(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom){
        MetricPair<Container, Cpu> pair = cpuService.getCpuMetrics(containerId,dateFrom);
        return conversion.convertToCpuDTO(pair.getMetrics(),pair.getContainer());
    }
    @GetMapping(value = "/", params = {"containerId", "dateFrom", "sampleRate"})
    @ResponseStatus(HttpStatus.OK)
    public CpuDTO getCpuMetWDateWSample(
            @RequestParam("containerId") String containerId,
            @RequestParam("dateFrom") Instant dateFrom,
            @RequestParam("sampleRate") SampledBy sampleRate){
        MetricPair<Container, Cpu> pair = cpuService.getCpuMetrics(containerId,dateFrom,sampleRate);
        return conversion.convertToCpuDTO(pair.getMetrics(),pair.getContainer());
    }
}

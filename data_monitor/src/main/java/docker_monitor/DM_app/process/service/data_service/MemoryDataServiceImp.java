package docker_monitor.DM_app.process.service.data_service;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.IO;
import docker_monitor.DM_app.process.database.entities.Memory;
import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.process.database.repository.ContainerRepository;
import docker_monitor.DM_app.process.database.repository.MemoryRepository;
import docker_monitor.DM_app.process.object.MetricPair;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.util.List;
import java.util.Optional;

@Service
public class MemoryDataServiceImp implements MemoryDataService{
    @Autowired
    MemoryRepository memoryRepository;

    @Autowired
    ContainerRepository containerRepository;

    public MetricPair<Container, Memory> getMemoryMetrics(String containerId,
                                                          Instant dateFrom,
                                                          Instant dateTo){
        Optional<Container> container = containerRepository.findBy(containerId);
        if(container.isEmpty())
            return null;
        List<Memory> metric = memoryRepository.findByContainerAndRange(containerId,dateFrom.toEpochMilli(),dateTo.toEpochMilli());
        return new MetricPair<>(container.get(),metric);
    }
    public MetricPair<Container, Memory> getMemoryMetrics(String containerId,
                                                  Instant dateFrom,
                                                  Instant dateTo,
                                                  SampledBy sampleRate){
        Optional<Container> container = containerRepository.findBy(containerId);
        if(container.isEmpty())
            return null;
        List<Memory> metric = memoryRepository.findByContainerAndRange(containerId,dateFrom.toEpochMilli(),dateTo.toEpochMilli(),sampleRate);
        return new MetricPair<>(container.get(),metric);
    }
    public MetricPair<Container, Memory> getMemoryMetrics(String containerId,
                                                  Instant dateFrom){
        Optional<Container> container = containerRepository.findBy(containerId);
        if(container.isEmpty())
            return null;
        List<Memory> metric = memoryRepository.findByContainerAndTime(containerId,dateFrom.toEpochMilli());
        return new MetricPair<>(container.get(),metric);
    }
    public MetricPair<Container, Memory> getMemoryMetrics(String containerId,
                                                  Instant dateFrom,
                                                  SampledBy sampleRate){
        Optional<Container> container = containerRepository.findBy(containerId);
        if(container.isEmpty())
            return null;
        List<Memory> metric = memoryRepository.findByContainerAndTime(containerId,dateFrom.toEpochMilli(),sampleRate);
        return new MetricPair<>(container.get(),metric);
    }
}

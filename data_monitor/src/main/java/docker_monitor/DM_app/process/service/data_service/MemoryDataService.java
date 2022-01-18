package docker_monitor.DM_app.process.service.data_service;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.Memory;
import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.process.object.MetricPair;

import java.time.Instant;
import java.util.List;
import java.util.Optional;

public interface MemoryDataService {
    MetricPair<Container, Memory> getMemoryMetrics(String containerId,
                                                          Instant dateFrom,
                                                          Instant dateTo);
    MetricPair<Container, Memory> getMemoryMetrics(String containerId,
                                                          Instant dateFrom,
                                                          Instant dateTo,
                                                          SampledBy sampleRate);
    MetricPair<Container, Memory> getMemoryMetrics(String containerId,
                                                          Instant dateFrom);
    MetricPair<Container, Memory> getMemoryMetrics(String containerId,
                                                          Instant dateFrom,
                                                          SampledBy sampleRate);
}

package docker_monitor.DM_app.process.service.data_service;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.Cpu;
import docker_monitor.DM_app.process.database.entities.IO;
import docker_monitor.DM_app.process.database.object.SampledBy;
import docker_monitor.DM_app.process.object.MetricPair;

import java.time.Instant;

public interface IODataService {
    MetricPair<Container, IO> getIOMetrics(String containerId,
                                            Instant dateFrom,
                                            Instant dateTo);
    MetricPair<Container, IO> getIOMetrics(String containerId,
                                             Instant dateFrom,
                                             Instant dateTo,
                                             SampledBy sampleRate);
    MetricPair<Container, IO> getIOMetrics(String containerId,
                                             Instant dateFrom);
    MetricPair<Container, IO> getIOMetrics(String containerId,
                                             Instant dateFrom,
                                             SampledBy sampleRate);
    void deleteDataTo(Instant dateTo);
}

package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.entities.Memory;
import org.springframework.stereotype.Repository;

@Repository
public class MemoryRepository extends MetricsRepository<Memory> {
    public MemoryRepository() {
        super(Memory.class);
    }
}
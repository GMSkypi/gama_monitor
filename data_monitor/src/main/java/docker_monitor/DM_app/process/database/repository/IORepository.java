package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.entities.IO;

import org.springframework.stereotype.Repository;

@Repository
public class IORepository extends MetricsRepository<IO> {
    public IORepository() {
        super(IO.class);
    }
}
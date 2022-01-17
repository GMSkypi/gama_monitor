package docker_monitor.DM_app.process.database.repository;


import docker_monitor.DM_app.process.database.entities.Net;
import org.springframework.stereotype.Repository;

@Repository
public class NetRepository extends MetricsRepository<Net> {
    public NetRepository() {
        super(Net.class);
    }
}
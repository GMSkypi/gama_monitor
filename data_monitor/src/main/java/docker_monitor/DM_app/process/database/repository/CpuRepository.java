package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.Cpu;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;
import org.springframework.stereotype.Repository;

@Repository
public class CpuRepository extends MetricsRepository<Cpu> {
    public CpuRepository() {
        super(Cpu.class);
    }
}
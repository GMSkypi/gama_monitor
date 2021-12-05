package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.entities.Cpu;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;

public class CpuRepository extends QuestDBRepositoryImp<Cpu> {
    public CpuRepository() {
        super(Cpu.class);
    }
}
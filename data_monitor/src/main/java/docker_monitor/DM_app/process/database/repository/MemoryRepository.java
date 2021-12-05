package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.entities.Memory;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;

public class MemoryRepository extends QuestDBRepositoryImp<Memory> {
    public MemoryRepository() {
        super(Memory.class);
    }
}
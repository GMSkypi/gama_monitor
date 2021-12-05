package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.entities.IO;

import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;

public class IORepository extends QuestDBRepositoryImp<IO> {
    public IORepository() {
        super(IO.class);
    }
}
package docker_monitor.DM_app.process.database.repository;


import docker_monitor.DM_app.process.database.entities.Net;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;

public class NetRepository extends QuestDBRepositoryImp<Net> {
    public NetRepository() {
        super(Net.class);
    }
}
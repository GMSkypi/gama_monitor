package docker_monitor.DM_app.process.database.repository;


import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;
import org.springframework.stereotype.Repository;

@Repository
public class ContainerRepository extends QuestDBRepositoryImp<Container> {
    public ContainerRepository() {
        super(Container.class);
    }
}


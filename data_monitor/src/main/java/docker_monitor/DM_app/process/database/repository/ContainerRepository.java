package docker_monitor.DM_app.process.database.repository;


import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public class ContainerRepository extends QuestDBRepositoryImp<Container> {
    public ContainerRepository() {
        super(Container.class);
    }
    public Optional<Container> findBy(String containerName){
        return executeQuery("SELECT * from " + Container.class.getAnnotation(Entity.class).name() +
                "WHERE id = " + containerName).stream().findFirst();
    }

}


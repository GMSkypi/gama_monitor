package docker_monitor.DM_app.process.database.repository;


import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.persistance.anotation.Aggregable;
import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;
import org.springframework.stereotype.Repository;

import java.lang.reflect.Field;
import java.time.Instant;
import java.util.Arrays;
import java.util.Iterator;
import java.util.List;
import java.util.Optional;

@Repository
public class ContainerRepository extends QuestDBRepositoryImp<Container> {
    public ContainerRepository() {
        super(Container.class);
    }

    private String allColumns(){
        StringBuilder result = new StringBuilder();
        Iterator<Field> fieldIterator = Arrays.stream(Container.class.getDeclaredFields()).iterator();

        while (fieldIterator.hasNext()) {
            Field f = fieldIterator.next();
            result.append(f.getAnnotation(Column.class).name());
            if(fieldIterator.hasNext()){
                result.append(", ");
            }
        }
        return result.toString();
    }

    public Optional<Container> findBy(String containerName){
        return executeQuery("SELECT "+ allColumns() + ",s1.date_time from " + Container.class.getAnnotation(Entity.class).name() +
                " join (SELECT date_time,Container_id FROM CPU\n" +
                "LATEST by Container_id ) as s1 on s1.Container_id = Container.id" +
                " WHERE id = '" + containerName + "'").stream().findFirst();
        /*
        return executeQuery("SELECT * from " + Container.class.getAnnotation(Entity.class).name() +
                " WHERE id = '" + containerName + "'").stream().findFirst();
                */

    }
    public List<Container> getContainersWithLastRecord(){
        return executeQuery("SELECT "+ allColumns() + ",s1.date_time from " + Container.class.getAnnotation(Entity.class).name() +
                " join (SELECT date_time,Container_id FROM CPU\n" +
                "LATEST by Container_id ) as s1 on s1.Container_id = Container.id");
    }
}


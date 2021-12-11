package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.entities.Container;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.repository.QuestDBRepositoryImp;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

public class MetricsRepository<C> extends QuestDBRepositoryImp<C> {
    private final Class<C> clazz;

    public MetricsRepository(Class<C> clazz) {
        super(clazz);
        this.clazz = clazz;
    }

    public List<C> findByContainerAndTime(String containerId, Date dateTime) {
            return executeQuery("SELECT * FROM " + clazz.getAnnotation(Entity.class).name() +
                    " WHERE Container_id= " + "'" + containerId + "'" + " and date_time >" + dateTime.getTime());
    }
    public List<C> findByContainerAndTime(String containerId, long dateTime) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.z");
        return executeQuery("SELECT * FROM " + clazz.getAnnotation(Entity.class).name() +
                " WHERE Container_id=" + "'" + containerId + "'" +" and date_time >" + "to_timestamp('" + dateFormat.format(dateTime) + "','yyyy-MM-dd HH:mm:ss.z')");
    }
}

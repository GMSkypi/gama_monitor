package docker_monitor.DM_app.process.database.persistance.repository;


import java.util.Date;
import java.util.List;

public interface QuestDBRepository<C> {
    List<C> executeQuery(String query);
    List<C> findAll();
}

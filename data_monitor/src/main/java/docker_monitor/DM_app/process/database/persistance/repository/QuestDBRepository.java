package docker_monitor.DM_app.process.database.persistance.repository;


public interface QuestDBRepository<C> {
    Iterable<C> findAll();
    Iterable<C> executeQuery(String query);
}

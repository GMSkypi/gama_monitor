package docker_monitor.DM_app.process.database.persistance.repository;


import docker_monitor.DM_app.process.database.db_source.DataSource;
import docker_monitor.DM_app.process.database.db_mapper.QuestDBDataMapper;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import org.springframework.beans.factory.annotation.Autowired;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public abstract class QuestDBRepositoryImp <C> implements QuestDBRepository<C> {

    @Autowired
    private DataSource datasource;

    @Autowired
    private QuestDBDataMapper dataMapper;

    private final Class<C> clazz;

    public QuestDBRepositoryImp(Class<C> clazz){
        this.clazz = clazz;
    }

    @Override
    public List<C> executeQuery(String query) {
        try{
            ResultSet resultset = datasource.executeQuery(query);
            List<C> cc = dataMapper.mapResultSet(resultset,clazz);
            resultset.close();
            return cc;
        }
        catch(SQLException exception){
            exception.printStackTrace();
            return new ArrayList<>();
        }
    }

    @Override
    public List<C> findAll() {
        return executeQuery("SELECT * FROM " + clazz.getAnnotation(Entity.class).name());
    }
}

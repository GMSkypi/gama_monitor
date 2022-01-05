package docker_monitor.DM_app.process.database.db_mapper;


import docker_monitor.DM_app.process.sql.CustomResultSet;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

public interface QuestDBDataMapper {
    <C> List<C> mapResultSet(CustomResultSet resultSet, Class<C> clazz) throws SQLException;
}

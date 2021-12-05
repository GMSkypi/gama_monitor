package docker_monitor.DM_app.process.database.db_mapper;


import java.sql.ResultSet;
import java.sql.SQLException;

public interface QuestDBDataMapper {
    <C> Iterable<C> mapResultSet(ResultSet resultSet, Class<C> clazz) throws SQLException;
}

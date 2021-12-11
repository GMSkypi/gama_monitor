package docker_monitor.DM_app.process.database.db_mapper;


import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

public interface QuestDBDataMapper {
    <C> List<C> mapResultSet(ResultSet resultSet, Class<C> clazz) throws SQLException;
}

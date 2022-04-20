package docker_monitor.DM_app.process.database.db_source;

import java.sql.ResultSet;
import java.sql.SQLException;

public interface DataSource {
    void connectionOpen() throws SQLException;
    void connectionClose() throws SQLException;
    public ResultSet executeQuery(String query) throws SQLException;
    boolean connectionAlive();
}

package docker_monitor.DM_app.process.sql;

import java.io.InputStream;
import java.io.Reader;
import java.math.BigDecimal;
import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.time.Instant;
import java.util.Calendar;
import java.util.Date;
import java.util.Map;
import java.util.TimeZone;

public class CustomResultSet  {

    private ResultSet resultSet;
    public CustomResultSet(ResultSet resultSet){
        this.resultSet = resultSet;
    }
    public int findColumn(String columnLabel) throws SQLException {
        return resultSet.findColumn(columnLabel);
    }
    public boolean next() throws SQLException {
        return resultSet.next();
    }
    public String getString(int columnIndex) throws SQLException {
        return resultSet.getString(columnIndex);
    }
    public int getInt(int columnIndex) throws SQLException {
        return resultSet.getInt(columnIndex);
    }
    public long getLong(int columnIndex) throws SQLException {
        return resultSet.getLong(columnIndex);
    }
    public Instant getDateTime(int columnIndex) throws SQLException {
        // in database UTC
        return Instant.ofEpochMilli(resultSet.getTimestamp(columnIndex).getTime());
    }
}

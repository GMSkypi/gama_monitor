package docker_monitor.DM_app.process.database.db_source;


import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.sql.*;
import java.util.Properties;

public class DataSourceImp implements DataSource {

    private static final Logger logger = LoggerFactory.getLogger(DataSourceImp.class);
    private String user;
    private String password;
    private String sslMode;
    private String conString;
    private int sessionDelay;
    private Connection connection;

    private static DataSourceImp selfRef;
    private DataSourceImp(String user, String password, String sslMode, String conString, int sessionDelay){
        this.user = user;
        this.password = password;
        this.sslMode = sslMode;
        this.conString = conString;
        this.sessionDelay = sessionDelay;
    }
    private DataSourceImp(){}
    public static DataSourceImp getInstance(String user, String password, String sslMode, String conString, int sessionDelay){
        if(selfRef == null)
            return new DataSourceImp(user,password,sslMode,conString,sessionDelay);
        return selfRef;
    }

    @Override
    public void connectionOpen() throws SQLException {
        if(connection == null || connection.isClosed()) {
            Properties properties = new Properties();
            properties.setProperty("user", this.user);
            properties.setProperty("password", this.password);
            properties.setProperty("sslmode", this.sslMode);
            connection = DriverManager.getConnection(this.conString, properties);
        }
    }

    @Override
    public void connectionClose() throws SQLException {
        connection.close();
        connection = null;
    }

    @Override
    public ResultSet executeQuery(String query) throws SQLException {
        connectionOpen();
        PreparedStatement preparedStatement = connection.prepareStatement(query);
        ResultSet r = preparedStatement.executeQuery();
        return r;

    }

    @Override
    public boolean connectionAlive() {
        try {
            executeQuery("SHOW TABLES");
            return true;
        } catch (SQLException e) {
            logger.error("Database is not reachable or not running");
            return false;
        }
    }

    @Override
    protected void finalize(){
        try {
            connection.close();
        }
        catch(SQLException e){
            logger.error("Connection to database can not be closed");
        }
    }
}

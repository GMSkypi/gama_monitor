package docker_monitor.DM_app.process.database.db_source;


import java.sql.*;
import java.util.Properties;

public class DataSourceImp implements DataSource {
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
    protected void finalize(){
        try {
            connection.close();
        }
        catch(SQLException e){
        }
    }
}

package docker_monitor.DM_app.process.database.db_source;

import java.io.*;
import java.util.Scanner;

public class NotificationDataSourceImp implements NotificationDataSource{
    String dataPath;
    public NotificationDataSourceImp(String dataPath){
        this.dataPath = dataPath;
    }

    @Override
    public boolean persist(String data) throws IOException {
        BufferedWriter writer = new BufferedWriter(new FileWriter(dataPath, false));
        writer.write(data);
        writer.close();
        return true;
    }

    @Override
    public String getNotifications() throws FileNotFoundException {
        String content = new Scanner(new File(dataPath)).useDelimiter("\\Z").next();
        return content;
    }
}

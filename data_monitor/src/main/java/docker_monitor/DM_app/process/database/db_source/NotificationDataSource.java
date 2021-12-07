package docker_monitor.DM_app.process.database.db_source;

import java.io.FileNotFoundException;
import java.io.IOException;

public interface NotificationDataSource {
    boolean persist(String data) throws IOException;
    String getNotifications() throws FileNotFoundException;
}

package docker_monitor.DM_app.process.service.cache;

import org.springframework.stereotype.Component;

import java.io.*;
import java.util.Properties;

import static java.lang.Boolean.parseBoolean;
import static java.lang.String.valueOf;

@Component
public class ConfigurationCache {
    private String urlSlackWebHook = "";
    private boolean notify = false;
    private final String filePath;

    public ConfigurationCache(String configurationFilePath){
        this.filePath = configurationFilePath;
        File configFile = new File(filePath);

        try {
            FileReader reader = new FileReader(configFile);
            Properties props = new Properties();
            props.load(reader);

            urlSlackWebHook = props.getProperty("slack.webhook");
            notify = parseBoolean(props.getProperty("notification.enabled"));
            reader.close();
        } catch (FileNotFoundException ex) {
            // file does not exist
        } catch (IOException ex) {
            // I/O error
        }
    }

    public String getUrlSlackWebHook() {
        return urlSlackWebHook;
    }

    public boolean setUrlSlackWebHook(String urlSlackWebHook) {
        this.urlSlackWebHook = urlSlackWebHook;
        return updateConfig();
    }

    public boolean isNotify() {
        return notify;
    }

    public boolean setNotify(boolean notify) {
        this.notify = notify;
        return updateConfig();

    }
    private boolean updateConfig(){
        File configFile = new File(filePath);
        try {
            Properties props = new Properties();
            props.setProperty("slack.webhook", urlSlackWebHook);
            props.setProperty("notification.enabled", valueOf(notify));
            FileWriter writer = new FileWriter(configFile);
            props.store(writer, "host settings");
            writer.close();
            return true;
        } catch (FileNotFoundException ex) {
            ex.printStackTrace();
            return false;
        } catch (IOException ex) {
            ex.printStackTrace();
            return false;
        }
    }
}

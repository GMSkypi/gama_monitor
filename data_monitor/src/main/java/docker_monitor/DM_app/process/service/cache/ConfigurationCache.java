package docker_monitor.DM_app.process.service.cache;

import docker_monitor.DM_app.process.service.ConfigurationLoader;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;
import java.util.Arrays;
import java.util.HashMap;


import static java.lang.Boolean.parseBoolean;
import static java.lang.String.valueOf;

@Component
public class ConfigurationCache {

    @Autowired
    ConfigurationLoader configurationLoader;

    private String urlSlackWebHook = "";
    private boolean notify = false;

    @PostConstruct
    public void initialize() {
        HashMap<String,String> values =
                configurationLoader.loadProps(Arrays.asList("slack.webhook","notification.enabled"));
        urlSlackWebHook = values.get("slack.webhook");
        notify = parseBoolean(values.get("notification.enabled"));
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
        HashMap<String,String> values = new HashMap<String, String>() {{
            put("slack.webhook", urlSlackWebHook);
            put("notification.enabled", valueOf(notify));
        }};
        return configurationLoader.saveProps(values,"host settings");

    }
}

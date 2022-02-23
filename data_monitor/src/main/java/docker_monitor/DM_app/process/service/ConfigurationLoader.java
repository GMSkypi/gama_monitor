package docker_monitor.DM_app.process.service;

import java.util.HashMap;
import java.util.List;

public interface ConfigurationLoader {
    HashMap<String, String> loadProps(List<String> propertyNames);
    boolean saveProps(HashMap<String, String> propstoSave, String message);
}

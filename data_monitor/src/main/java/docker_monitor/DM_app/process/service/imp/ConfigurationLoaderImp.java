package docker_monitor.DM_app.process.service.imp;

import docker_monitor.DM_app.process.notification_message_handler.SlackHandler;
import docker_monitor.DM_app.process.service.ConfigurationLoader;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.*;
import java.util.HashMap;
import java.util.List;
import java.util.Properties;

import static java.lang.Boolean.parseBoolean;
import static java.lang.String.valueOf;

@Service
public class ConfigurationLoaderImp implements ConfigurationLoader {
    private static final Logger logger = LoggerFactory.getLogger(ConfigurationLoaderImp.class);
    @Autowired
    private  String configurationFilePath;


    public HashMap<String, String> loadProps(List<String> propertyNames){
        File configFile = new File(configurationFilePath);
        HashMap<String, String> result = new HashMap<>();
        try {
            FileReader reader = new FileReader(configFile);
            Properties props = new Properties();
            props.load(reader);
            for(String prop : propertyNames)
                result.put(prop,props.getProperty(prop));
            reader.close();
        } catch (FileNotFoundException ex) {
            logger.error("File not found: " + configurationFilePath,ex);
        } catch (IOException ex) {
            logger.error("I/O error: " + configurationFilePath,ex);
        }
        return result;
    }
    public boolean saveProps(HashMap<String, String> propstoSave, String message){
        File configFile = new File(configurationFilePath);
        try {
            FileReader reader = new FileReader(configFile);
            Properties props = new Properties();
            props.load(reader);
            propstoSave.forEach(props::setProperty);
            FileWriter writer = new FileWriter(configFile);
            props.store(writer, message);
            writer.close();
            return true;
        } catch (FileNotFoundException ex) {
            logger.error("File not found: " + configurationFilePath,ex);
            return false;
        } catch (IOException ex) {
            logger.error("I/O error: " + configurationFilePath,ex);
            return false;
        }
    }

}

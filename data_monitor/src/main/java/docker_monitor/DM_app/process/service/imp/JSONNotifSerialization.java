package docker_monitor.DM_app.process.service.imp;


import com.fasterxml.jackson.annotation.JsonAutoDetect;
import com.fasterxml.jackson.annotation.PropertyAccessor;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import docker_monitor.DM_app.process.database.db_source.NotificationDataSource;
import docker_monitor.DM_app.process.object.notification.Notification;
import docker_monitor.DM_app.process.service.NotificationSerialization;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

@Service
public class JSONNotifSerialization implements NotificationSerialization {

    private static final Logger logger = LoggerFactory.getLogger(JSONNotifSerialization.class);
    @Autowired
    private NotificationDataSource dataSource;

    @Override
    public boolean serialize(Iterable<Notification> notifications) {
        try {
            ObjectMapper objectMapper = new ObjectMapper();
            objectMapper.setVisibility(PropertyAccessor.FIELD, JsonAutoDetect.Visibility.ANY);
            String data = objectMapper.writeValueAsString(notifications);
            dataSource.persist(data);
            return true;
        } catch(IOException e){
            logger.error("Serialization error",e);
            return false;
        }
    }

    @Override
    public List<Notification> loadObjects() {
        try{
            ObjectMapper objectMapper = new ObjectMapper();
            String data = dataSource.getNotifications();
            return objectMapper.readValue(data, new TypeReference<List<Notification>>(){});
        } catch(FileNotFoundException e){
            logger.info("Notification file not found, creating new file.");
        } catch (JsonMappingException e) {
            logger.info("Mapping failed",e);
        } catch (JsonProcessingException e) {
            logger.info("Mapping failed",e);
        }
        return  new ArrayList<>();
    }
}

package docker_monitor.DM_app.process.service;


import com.fasterxml.jackson.annotation.JsonAutoDetect;
import com.fasterxml.jackson.annotation.PropertyAccessor;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import docker_monitor.DM_app.process.database.db_source.NotificationDataSource;
import docker_monitor.DM_app.process.object.Notification;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

@Service
public class JSONNotifSerialization implements NotificationSerialization{
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
            e.printStackTrace();
            return false;
        }
    }

    @Override
    public ArrayList<Notification> loadObjects() {
        try{
            ObjectMapper objectMapper = new ObjectMapper();
            String data = dataSource.getNotifications();
            return objectMapper.readValue(data, new TypeReference<ArrayList<Notification>>(){});
        } catch(FileNotFoundException e){
            e.printStackTrace();
        } catch (JsonMappingException e) {
            e.printStackTrace();
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        return null;
    }
}

package docker_monitor.DM_app.process.service;

import docker_monitor.DM_app.process.service.cache.NotificationCache;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Service;

@Service
public class MetricsMonitorImp implements MetricsMonitor {
    @Autowired
    NotificationCache cache;


    @Scheduled(fixedRate = 1000)
    public void checkMetrics(){
        //System.out.println("1");
    }
}

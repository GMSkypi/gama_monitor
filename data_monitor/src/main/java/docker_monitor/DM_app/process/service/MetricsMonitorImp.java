package docker_monitor.DM_app.process.service;

import docker_monitor.DM_app.constants.Group;
import docker_monitor.DM_app.process.database.entities.Cpu;
import docker_monitor.DM_app.process.database.entities.IO;
import docker_monitor.DM_app.process.database.entities.Memory;
import docker_monitor.DM_app.process.database.entities.Net;
import docker_monitor.DM_app.process.database.repository.*;
import docker_monitor.DM_app.process.object.ActiveNotification;
import docker_monitor.DM_app.process.object.Metric;
import docker_monitor.DM_app.process.object.Notification;
import docker_monitor.DM_app.process.service.cache.NotificationCache;
import org.apache.logging.log4j.util.TriConsumer;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Service;

import java.util.*;
import java.util.function.BiConsumer;
import java.util.function.Consumer;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import static docker_monitor.DM_app.process.object.Threshold.MAX;


@Service
public class MetricsMonitorImp implements MetricsMonitor {
    @Autowired
    NotificationCache cache;

    @Autowired
    ContainerRepository containerRepository;

    @Autowired
    CpuRepository cpuRepository;

    @Autowired
    IORepository ioRepository;

    @Autowired
    MemoryRepository memoryRepository;

    @Autowired
    NetRepository netRepository;


    @Scheduled(fixedRate = 1000)
    public void checkMetrics(){
        Date dateTimeNow = new Date();
        List<ActiveNotification> notificationList = cache.getNotifications();
        LinkedList<ActiveNotification> notificationQueue = new LinkedList<>();
        Map<Group, Long> metricGroupLatestRecordTime = new HashMap<>();

        for(ActiveNotification notification : notificationList){
            if(dateTimeNow.after(notification.getLastCheckTime()) && dateTimeNow.after( notification.getLastNotificationTime())){
                if(!notificationQueue.isEmpty() && !Objects.equals(notificationQueue.peek().getNotification().getContainerId(), notification.getNotification().getContainerId())){
                    handleChecking(metricGroupLatestRecordTime,notificationQueue,dateTimeNow);
                    notificationQueue = new LinkedList<>();
                    metricGroupLatestRecordTime = new HashMap<>();
                }
                notificationQueue.offer(notification);
                calculateLatestRecord(notification,metricGroupLatestRecordTime);
            }
        }
        handleChecking(metricGroupLatestRecordTime,notificationQueue,dateTimeNow);
    }
    public void checkThresholdNotification(ActiveNotification activeNotification, List<Metric> metrics, Date dateTimeNow){
        // TODO INJECTION OF DATE INSTEAD OF TIMESTAMP
        Stream<Metric> filteredMetrics = metrics.stream().filter(a -> a.getDateTime().getTime() > (dateTimeNow.getTime() - activeNotification.getNotification().getOverTime()));
        long value;
        if(!metrics.isEmpty()) {
            value = switch (activeNotification.getNotification().getThresholdNotify().getThrashold()) {
                case MAX -> filteredMetrics.max(Comparator.comparing(Metric::getValue)).get().getValue();
                case MIN -> filteredMetrics.min(Comparator.comparing(Metric::getValue)).get().getValue();
                case AVERAGE -> Math.round(filteredMetrics.mapToDouble(Metric::getValue).average().orElse(Double.NaN));
                case MEDIAN -> {
                    List<Metric> sortedM = filteredMetrics.sorted().toList();
                    yield sortedM.size() != 0 ? sortedM.get(sortedM.size() / 2).getValue() : 0;
                }
            };
        }
        else value = 0;
        boolean notify = switch (activeNotification.getNotification().getThresholdNotify().getTrigger()){
            case ABOVE -> value > activeNotification.getNotification().getValue();
            case BELOW -> value < activeNotification.getNotification().getValue();
        };
        activeNotification.setLastCheckTime(new Date(dateTimeNow.getTime() + activeNotification.getNotification().getOverTime()));
        if(notify){
            System.out.println("NOTIFICATION: CONT_ID:" + activeNotification.getNotification().getContainerId() +
                    " METRIC: " + activeNotification.getNotification().getMetricToMonitor() +
                    activeNotification.getNotification().getThresholdNotify().getThrashold() +  " VALUE: " + value +
                    " IS " + activeNotification.getNotification().getThresholdNotify().getTrigger() +
                    " DECLARED: " + activeNotification.getNotification().getValue());
            activeNotification.setLastNotificationTime(new Date(dateTimeNow.getTime() + activeNotification.getNotification().getNotificationDelay()));
        }
    }
    public void checkChangeNotification(ActiveNotification activeNotification, List<Metric> metrics, Date dateTimeNow){

    }
    public void calculateLatestRecord(ActiveNotification activeNotification,  Map<Group, Long> metricGroupLatestRecordTime){
        Notification notification = activeNotification.getNotification();
        long time = switch(notification.getType()) {
            case THRESHOLD -> notification.getOverTime();
            case CHANGE -> notification.getOverTime() + notification.getChangeNotify().getComparedToBefore();
        };
        Group key = activeNotification.getNotification().getMetricGroup();
        if(!metricGroupLatestRecordTime.containsKey(key)) metricGroupLatestRecordTime.put(key,time);
        else if(metricGroupLatestRecordTime.get(key) < time) metricGroupLatestRecordTime.put(key,time);
    }
    public void handleChecking( Map<Group, Long> metricGroupLatestRecordTime, LinkedList<ActiveNotification> notificationQueue, Date dateTimeNow){
        if (notificationQueue.peek() == null) return;
        String containerId = notificationQueue.peek().getNotification().getContainerId();
        long dateNow = dateTimeNow.getTime();
        List<Cpu> cpuMetric = (metricGroupLatestRecordTime.get(Group.CPU) != null ?
                cpuRepository.findByContainerAndTime(containerId, dateNow - metricGroupLatestRecordTime.get(Group.CPU)) : new ArrayList<>());
        List<IO> ioMetric = (metricGroupLatestRecordTime.get(Group.IO) != null ?
                ioRepository.findByContainerAndTime(containerId, dateNow - metricGroupLatestRecordTime.get(Group.IO)) : new ArrayList<>());
        List<Memory> memoryMetric = (metricGroupLatestRecordTime.get(Group.MEMORY) != null ?
                memoryRepository.findByContainerAndTime(containerId, dateNow - metricGroupLatestRecordTime.get(Group.MEMORY)) : new ArrayList<>());
        List<Net> netMetric = (metricGroupLatestRecordTime.get(Group.NET) != null ?
                netRepository.findByContainerAndTime(containerId, dateNow - metricGroupLatestRecordTime.get(Group.NET)) : new ArrayList<>());

        while(!notificationQueue.isEmpty()){
            ActiveNotification activeNotification = notificationQueue.poll();
            TriConsumer<ActiveNotification,List<Metric>,Date> checkHandler = switch (activeNotification.getNotification().getType()){
                case CHANGE ->  this::checkChangeNotification;
                case THRESHOLD -> this::checkThresholdNotification;
            };
            switch(activeNotification.getNotification().getMetricGroup()){
                case CPU -> {
                    switch (activeNotification.getNotification().getMetricToMonitor()){
                        case U_SPACE_PR -> checkHandler.accept(activeNotification,cpuMetric.stream().map(a -> new Metric(a.getUserSpacePercents(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case K_SPACE_PR -> checkHandler.accept(activeNotification,cpuMetric.stream().map(a -> new Metric(a.getKernelSpacePercents(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case U_SPACE_MS -> checkHandler.accept(activeNotification,cpuMetric.stream().map(a -> new Metric(a.getUserSpaceMs(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case K_SPACE_MS -> checkHandler.accept(activeNotification,cpuMetric.stream().map(a -> new Metric(a.getKernelSpaceMs(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case THROTTLE_NS -> checkHandler.accept(activeNotification,cpuMetric.stream().map(a -> new Metric(a.getThrottleMs(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case THROTTLE_CNT -> checkHandler.accept(activeNotification,cpuMetric.stream().map(a -> new Metric(a.getThrottleCount(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case TOTAL_NS -> checkHandler.accept(activeNotification,cpuMetric.stream().map(a -> new Metric(a.getTotalMs(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case TOTAL_PR -> checkHandler.accept(activeNotification,cpuMetric.stream().map(a -> new Metric(a.getTotalPercents(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                    }
                }
                case IO -> {

                }
                case MEMORY -> {

                }
                case NET -> {

                }
            }
        }
    }
}

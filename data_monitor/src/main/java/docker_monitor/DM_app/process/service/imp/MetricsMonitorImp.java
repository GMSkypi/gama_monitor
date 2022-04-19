package docker_monitor.DM_app.process.service.imp;

import docker_monitor.DM_app.constants.Group;
import docker_monitor.DM_app.process.database.entities.Cpu;
import docker_monitor.DM_app.process.database.entities.IO;
import docker_monitor.DM_app.process.database.entities.Memory;
import docker_monitor.DM_app.process.database.entities.Net;
import docker_monitor.DM_app.process.database.repository.*;
import docker_monitor.DM_app.process.object.notification.ActiveNotification;
import docker_monitor.DM_app.process.object.notification.Metric;
import docker_monitor.DM_app.process.object.notification.Notification;
import docker_monitor.DM_app.process.service.MessageNotification;
import docker_monitor.DM_app.process.service.MetricsMonitor;
import docker_monitor.DM_app.process.service.cache.NotificationCache;
import org.apache.logging.log4j.util.TriConsumer;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;



@Service
public class MetricsMonitorImp implements MetricsMonitor {

    private static final Logger logger = LoggerFactory.getLogger(MetricsMonitorImp.class);
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

    @Autowired
    MessageNotification notification;


    @Scheduled(fixedRate = 1000)
    public void checkMetrics(){
        Instant dateTimeNow = Instant.now();

        List<ActiveNotification> notificationList = cache.getNotifications();
        LinkedList<ActiveNotification> notificationQueue = new LinkedList<>();
        Map<Group, Long> metricGroupLatestRecordTime = new HashMap<>();

        for(ActiveNotification notification : notificationList){
            if(dateTimeNow.isAfter(notification.getLastCheckTime()) && dateTimeNow.isAfter( notification.getLastNotificationTime())){
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
    public void checkThresholdNotification(ActiveNotification activeNotification, List<Metric> metrics, Instant dateTimeNow){
        Stream<Metric> stream =
                metrics.stream().filter(a -> a.getDateTime().toEpochMilli() > (dateTimeNow.toEpochMilli() - activeNotification.getNotification().getOverTime()));

        long value = switch (activeNotification.getNotification().getThresholdNotify().getThreshold()) {
                case MAX -> stream.map(Metric::getValue).reduce(Math::max).orElse(0L);
                case MIN -> stream.map(Metric::getValue).reduce(Math::min).orElse(0L);
                case AVERAGE -> Math.round(stream.mapToDouble(Metric::getValue).average().orElse(0L));
                case MEDIAN -> {
                    List<Metric> sortedM = stream.sorted().toList();
                    yield sortedM.size() != 0 ? sortedM.get(sortedM.size() / 2).getValue() : 0;
                }
        };
        boolean notify = switch (activeNotification.getNotification().getThresholdNotify().getTrigger()){
            case ABOVE -> value > activeNotification.getNotification().getValue();
            case BELOW -> value < activeNotification.getNotification().getValue();
        };
        activeNotification.setLastCheckTime(Instant.ofEpochMilli(dateTimeNow.toEpochMilli() + activeNotification.getNotification().getOverTime()));
        if(notify){
            logger.info("NOTIFICATION THRESHOLD: CONT_ID:" + activeNotification.getNotification().getContainerId() +
                    " METRIC: " + activeNotification.getNotification().getMetricToMonitor() +
                    activeNotification.getNotification().getThresholdNotify().getThreshold() +  " VALUE: " + value +
                    " IS " + activeNotification.getNotification().getThresholdNotify().getTrigger() +
                    " DECLARED: " + activeNotification.getNotification().getValue());
            activeNotification.setLastNotificationTime(Instant.ofEpochMilli(dateTimeNow.toEpochMilli() + activeNotification.getNotification().getNotificationDelay()));
            notification.notifyObservers(activeNotification.getNotification(),value);
        }
    }
    public void checkChangeNotification(ActiveNotification activeNotification, List<Metric> metrics, Instant dateTimeNow){
        Stream<Metric> comparingStream =
                metrics.stream().filter(a -> a.getDateTime().toEpochMilli() > (dateTimeNow.toEpochMilli() - activeNotification.getNotification().getOverTime()));
        Stream<Metric> beforeStream =
                metrics.stream().filter(a -> a.getDateTime().toEpochMilli() > (dateTimeNow.toEpochMilli() - activeNotification.getNotification().getOverTime() - activeNotification.getNotification().getChangeNotify().getComparedToBefore()))
                        .filter((a -> dateTimeNow.toEpochMilli() - activeNotification.getNotification().getOverTime() > a.getDateTime().toEpochMilli()));

        long value = Math.round(comparingStream.mapToDouble(Metric::getValue).average().orElse(0)) -
                    Math.round(beforeStream.mapToDouble(Metric::getValue).average().orElse(0));
        boolean notify = switch (activeNotification.getNotification().getChangeNotify().getTrigger()){
            case BELOW -> value < 0 && Math.abs(value) > activeNotification.getNotification().getValue();
            case ABOVE -> value > 0 &&  value > activeNotification.getNotification().getValue();
        };
        activeNotification.setLastCheckTime(Instant.ofEpochMilli(dateTimeNow.toEpochMilli() + activeNotification.getNotification().getOverTime()));
        if(notify){
            logger.info("NOTIFICATION CHANGE: CONT_ID:" + activeNotification.getNotification().getContainerId() +
                    " METRIC: " + activeNotification.getNotification().getMetricToMonitor() +
                     " VALUE: " + value +
                    " IS " + activeNotification.getNotification().getChangeNotify().getTrigger() +
                    " DECLARED: " + activeNotification.getNotification().getValue());
            activeNotification.setLastNotificationTime(Instant.ofEpochMilli(dateTimeNow.toEpochMilli() + activeNotification.getNotification().getNotificationDelay()));
            notification.notifyObservers(activeNotification.getNotification(),Math.abs(value));
        }

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
    public void handleChecking( Map<Group, Long> metricGroupLatestRecordTime, LinkedList<ActiveNotification> notificationQueue, Instant dateTimeNow){
        if (notificationQueue.peek() == null) return;
        String containerId = notificationQueue.peek().getNotification().getContainerId();
        long dateNow = dateTimeNow.toEpochMilli();
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
            TriConsumer<ActiveNotification,List<Metric>,Instant> checkHandler = switch (activeNotification.getNotification().getType()){
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
                        default -> logger.debug("Notification metric mismatch: CPU -->" + activeNotification.getNotification().getMetricToMonitor().toString());
                    }
                }
                case IO -> {
                    switch (activeNotification.getNotification().getMetricToMonitor()){
                        case READ -> checkHandler.accept(activeNotification,ioMetric.stream().map(a -> new Metric(a.getByteRead(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case WRITE -> checkHandler.accept(activeNotification,ioMetric.stream().map(a -> new Metric(a.getByteWrite(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        default -> logger.debug("Notification metric mismatch: IO -->" + activeNotification.getNotification().getMetricToMonitor().toString());
                    }
                }
                case MEMORY -> {
                    switch (activeNotification.getNotification().getMetricToMonitor()){
                        case MEM_USED -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getMemoryUsed(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case MEM_SWAP_USED -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getMemoryAndSwapUsed(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case RSS -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getRss(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case CACHE_C -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getCache(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case SWAP -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getSwap(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case MEM_LIMIT -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getMemoryLimit(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case MEM_SWAP_LIMIT -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getMemoryAndSwapLimit(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case MEM_HIT_CNT -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getMemoryLimitHitCount(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case MEM_SWAP_HIT_CNT -> checkHandler.accept(activeNotification,memoryMetric.stream().map(a -> new Metric(a.getMemoryAndSwapLimitHitCount(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        default -> logger.debug("Notification metric mismatch: MEMORY -->" + activeNotification.getNotification().getMetricToMonitor().toString());
                    }
                }
                case NET -> {
                    switch (activeNotification.getNotification().getMetricToMonitor()){
                        case RECEIVE -> checkHandler.accept(activeNotification,netMetric.stream().map(a -> new Metric(a.getReceive(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case RECEIVE_ERROR -> checkHandler.accept(activeNotification,netMetric.stream().map(a -> new Metric(a.getReceiveErrorCountPeriod(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case RECEIVE_ERROR_TOTAL -> checkHandler.accept(activeNotification,netMetric.stream().map(a -> new Metric(a.getReceiveErrorCountTotal(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case TRANSMIT -> checkHandler.accept(activeNotification,netMetric.stream().map(a -> new Metric(a.getTransmit(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case TRANSMIT_ERROR -> checkHandler.accept(activeNotification,netMetric.stream().map(a -> new Metric(a.getTransmitErrorCountPeriod(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        case TRANSMIT_ERROR_TOTAL -> checkHandler.accept(activeNotification,netMetric.stream().map(a -> new Metric(a.getTransmitErrorCountTotal(),a.getDateTime())).collect(Collectors.toList()),dateTimeNow);
                        default -> logger.debug("Notification metric mismatch: NET -->" + activeNotification.getNotification().getMetricToMonitor().toString());
                    }
                }
            }
        }
    }
}

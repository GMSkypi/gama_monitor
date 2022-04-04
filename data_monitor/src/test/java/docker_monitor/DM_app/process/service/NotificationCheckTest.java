package docker_monitor.DM_app.process.service;

import docker_monitor.DM_app.constants.Metrics;
import docker_monitor.DM_app.constants.Group;
import docker_monitor.DM_app.process.database.entities.IO;
import docker_monitor.DM_app.process.database.repository.*;
import docker_monitor.DM_app.process.object.notification.*;
import docker_monitor.DM_app.process.service.cache.NotificationCache;
import docker_monitor.DM_app.process.service.imp.MetricsMonitorImp;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.context.jdbc.Sql;

import java.time.Instant;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Stream;

import static org.junit.jupiter.params.provider.Arguments.arguments;
import static org.mockito.ArgumentMatchers.*;
import static org.mockito.Mockito.never;
import static org.mockito.Mockito.verify;

@TestPropertySource(locations= "classpath:defaultTest.properties")
@SpringBootTest
@ContextConfiguration(classes = DatabaseTestConfiguration.class)
@Sql("classpath:schema.sql")
@Sql("classpath:import.sql")
public class NotificationCheckTest {

    @Autowired
    MetricsMonitorImp metricsMonitor;

    @MockBean
    NotificationCache cache;

    @MockBean
    ContainerRepository containerRepository;

    @MockBean
    CpuRepository cpuRepository;

    @MockBean
    IORepository ioRepository;

    @MockBean
    MemoryRepository memoryRepository;

    @MockBean
    NetRepository netRepository;

    @MockBean
    MessageNotification notification;

    static Stream<Arguments> thresholdParamProvider() {
        return Stream.of(
                arguments(true, 10,3000,Trigger.ABOVE,Threshold.AVERAGE,15),
                arguments(true, 9,1500,Trigger.ABOVE,Threshold.AVERAGE,10),
                arguments(false, 10,1500,Trigger.ABOVE,Threshold.AVERAGE,10),
                arguments(true, 5,3000,Trigger.ABOVE,Threshold.MAX,20),
                arguments(true, 11,3000,Trigger.BELOW,Threshold.MIN,10),
                arguments(false, 5,3000,Trigger.BELOW,Threshold.MIN,10)
        );
    }
    @ParameterizedTest
    @MethodSource("thresholdParamProvider")
    void thresholdNotificationTest(boolean notify, int triggerVal, int overtime, Trigger trigger, Threshold threshold, long output){
        List<ActiveNotification> notificationList = new ArrayList<>();
        notificationList.add(
                new ActiveNotification(
                        new Notification("container_1",
                                Metrics.READ,
                                Group.IO,
                                "test message",
                                triggerVal,
                                overtime,
                                new ThresholdNotify(trigger, threshold),
                                10)));
        IO metric1 = new IO();
        metric1.setDateTime(Instant.now());
        metric1.setByteRead(10);

        IO metric2 = new IO();
        metric2.setDateTime(Instant.ofEpochMilli(Instant.now().toEpochMilli() - 2000));
        metric2.setByteRead(20);

        List<IO> ioMetric = new ArrayList<>();
        ioMetric.add(metric1);
        ioMetric.add(metric2);

        Mockito.when(cache.getNotifications())
                .thenReturn(notificationList);

        Mockito.when(ioRepository.findByContainerAndTime(matches("container_1"),any(Long.class)))
                .thenReturn(ioMetric);

        metricsMonitor.checkMetrics();

        if(notify) verify(notification).notifyObservers(any(Notification.class),eq(output));
        else verify(notification, never()).notifyObservers(any(Notification.class),any(Long.class));
    }
    static Stream<Arguments> changeParamProvider() {
        return Stream.of(
                arguments(true, false, 9, 1000, Trigger.BELOW, 3000, 10),
                arguments(false, false, 11, 1000, Trigger.BELOW, 3000, 10),
                arguments(false, false, 11, 1000, Trigger.ABOVE, 3000, 10),
                arguments(false, false, 9, 1000, Trigger.ABOVE, 3000, 10),

                arguments(false, true, 11, 1000, Trigger.BELOW, 3000, 10),
                arguments(false, true, 9, 1000, Trigger.BELOW, 3000, 10),
                arguments(false, true, 11, 1000, Trigger.ABOVE, 3000, 10),
                arguments(true, true, 9, 1000, Trigger.ABOVE, 3000, 10)
        );
    }
    @ParameterizedTest
    @MethodSource("changeParamProvider")
    void changeNotificationTest(boolean notify, boolean switchTimes, int triggerVal, int overtime, Trigger trigger, long before, long output){
        List<ActiveNotification> notificationList = new ArrayList<>();
        notificationList.add(
                new ActiveNotification(
                        new Notification("container_1",
                                Metrics.READ,
                                Group.IO,
                                "test message",
                                triggerVal,
                                overtime,
                                new ChangeNotify(trigger,before),
                                10)));
        IO metric1 = new IO();
        IO metric2 = new IO();

        metric1.setByteRead(10);
        metric2.setByteRead(20);

        if(!switchTimes){
            metric1.setDateTime(Instant.now());
            metric2.setDateTime(Instant.ofEpochMilli(Instant.now().toEpochMilli() - 2000));
        }
        else{
            metric2.setDateTime(Instant.now());
            metric1.setDateTime(Instant.ofEpochMilli(Instant.now().toEpochMilli() - 2000));
        }

        List<IO> ioMetric = new ArrayList<>();
        ioMetric.add(metric1);
        ioMetric.add(metric2);

        Mockito.when(cache.getNotifications())
                .thenReturn(notificationList);

        Mockito.when(ioRepository.findByContainerAndTime(matches("container_1"),any(Long.class)))
                .thenReturn(ioMetric);

        metricsMonitor.checkMetrics();

        if(notify) verify(notification).notifyObservers(any(Notification.class),eq(output));
        else verify(notification, never()).notifyObservers(any(Notification.class),any(Long.class));
    }

    static Stream<Arguments> timingParamProvider() {
        return Stream.of(
                arguments(false,4000,0),
                arguments(true,0,0),
                arguments(true,-1000,0),
                arguments(true,-3000,0),
                arguments(true,0,-1000),
                arguments(false,0,1000),
                arguments(false,1000,1000),
                arguments(false,1000,5000)
        );
    }
    @ParameterizedTest
    @MethodSource("timingParamProvider")
    void timingTest(boolean notify, long lastCheckTimePlus, long lastNotifTimePlus){
        List<ActiveNotification> notificationList = new ArrayList<>();
        notificationList.add(
                new ActiveNotification(
                        new Notification("container_1",
                                Metrics.READ,
                                Group.IO,
                                "test message",
                                10,
                                3000,
                                new ThresholdNotify(Trigger.ABOVE, Threshold.AVERAGE),
                                10000)));
        notificationList.get(0).setLastCheckTime(Instant.ofEpochMilli(Instant.now().toEpochMilli() + lastCheckTimePlus));
        notificationList.get(0).setLastNotificationTime(Instant.ofEpochMilli(Instant.now().toEpochMilli() + lastNotifTimePlus));
        IO metric1 = new IO();
        metric1.setDateTime(Instant.now());
        metric1.setByteRead(10);

        IO metric2 = new IO();
        metric2.setDateTime(Instant.ofEpochMilli(Instant.now().toEpochMilli() - 2000));
        metric2.setByteRead(20);

        List<IO> ioMetric = new ArrayList<>();
        ioMetric.add(metric1);
        ioMetric.add(metric2);

        Mockito.when(cache.getNotifications())
                .thenReturn(notificationList);

        Mockito.when(ioRepository.findByContainerAndTime(matches("container_1"),any(Long.class)))
                .thenReturn(ioMetric);

        metricsMonitor.checkMetrics();

        if(notify) verify(ioRepository).findByContainerAndTime(matches("container_1"),any(Long.class));
        else verify(ioRepository, never()).findByContainerAndTime(matches("container_1"),any(Long.class));
    }
}

package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.db_source.DataSource;
import docker_monitor.DM_app.process.database.entities.Cpu;
import docker_monitor.DM_app.process.database.entities.IO;
import docker_monitor.DM_app.process.database.entities.Memory;
import docker_monitor.DM_app.process.database.entities.Net;
import org.checkerframework.checker.units.qual.A;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.context.jdbc.Sql;

import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.time.Instant;
import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;

@TestPropertySource(locations= "classpath:defaultTest.properties")
@SpringBootTest
@ContextConfiguration(classes = DatabaseTestConfiguration.class)
@Sql("classpath:schema.sql")
@Sql("classpath:import.sql")
public class MetricRepositoryTest {

    @Autowired
    CpuRepository cpuRepository;

    @Autowired
    IORepository ioRepository;

    @Autowired
    MemoryRepository memoryRepository;

    @Autowired
    NetRepository netRepository;

    @Autowired
    DataSource dataSource;

    @Test
    public void cpuParserTest(){
        List<Cpu> metric =  cpuRepository.findAll();
        assertThat(metric.size()).isEqualTo(2);
        assertThat(metric.get(0).getContainerId()).isEqualTo("data_collector");
        assertThat(metric.get(0).getUserSpacePercents()).isEqualTo(1192);
        assertThat(metric.get(0).getKernelSpacePercents()).isEqualTo(198);
        assertThat(metric.get(0).getUserSpaceMs()).isEqualTo(60);
        assertThat(metric.get(0).getKernelSpaceMs()).isEqualTo(10);
        assertThat(metric.get(0).getThrottleMs()).isEqualTo(0);
        assertThat(metric.get(0).getThrottleCount()).isEqualTo(0);
        assertThat(metric.get(0).getTotalMs()).isEqualTo(51);
        assertThat(metric.get(0).getTotalPercents()).isEqualTo(1027);
        assertThat(metric.get(0).getDateTime()).isEqualTo(Instant.parse("2022-01-04T13:59:30.204Z"));
    }
    @Test
    public void ioParserTest(){
        List<IO> metric =  ioRepository.findAll();
        assertThat(metric.size()).isEqualTo(2);
        assertThat(metric.get(0).getContainerId()).isEqualTo("data_collector");
        assertThat(metric.get(0).getByteRead()).isEqualTo(4096);
        assertThat(metric.get(0).getByteWrite()).isEqualTo(0);
        assertThat(metric.get(0).getDateTime()).isEqualTo(Instant.parse("2021-11-29T11:32:23.973Z"));
    }
    @Test
    public void memoryParserTest(){
        List<Memory> metric =  memoryRepository.findAll();
        assertThat(metric.size()).isEqualTo(2);
        assertThat(metric.get(0).getContainerId()).isEqualTo("data_collector");
        assertThat(metric.get(0).getMemoryUsed()).isEqualTo(2306048);
        assertThat(metric.get(0).getMemoryAndSwapUsed()).isEqualTo(2301952);
        assertThat(metric.get(0).getRss()).isEqualTo(675840);
        assertThat(metric.get(0).getCache()).isEqualTo(1216512);
        assertThat(metric.get(0).getSwap()).isEqualTo(0);
        assertThat(metric.get(0).getMemoryLimit()).isEqualTo(0);
        assertThat(metric.get(0).getMemoryAndSwapLimit()).isEqualTo(0);
        assertThat(metric.get(0).getMemoryLimitHitCount()).isEqualTo(0);
        assertThat(metric.get(0).getMemoryAndSwapLimitHitCount()).isEqualTo(0);
        assertThat(metric.get(0).getDateTime()).isEqualTo(Instant.parse("2021-11-29T11:32:13.866Z"));
    }
    @Test
    public void netParserTest() throws SQLException {

        List<Net> metric =  netRepository.findAll();
        assertThat(metric.size()).isEqualTo(2);
        assertThat(metric.get(0).getContainerId()).isEqualTo("data_collector");
        assertThat(metric.get(0).getReceive()).isEqualTo(50445);
        assertThat(metric.get(0).getReceiveErrorCountPeriod()).isEqualTo(0);
        assertThat(metric.get(0).getReceiveErrorCountTotal()).isEqualTo(0);
        assertThat(metric.get(0).getTransmit()).isEqualTo(38958);
        assertThat(metric.get(0).getTransmitErrorCountPeriod()).isEqualTo(0);
        assertThat(metric.get(0).getTransmitErrorCountTotal()).isEqualTo(0);
        assertThat(metric.get(0).getDateTime()).isEqualTo(Instant.parse("2021-11-29T11:32:34.052Z"));
    }
    @Test
    public void cpuFindTest(){
        List<Cpu> cpuMetric =  cpuRepository.findByContainerAndTime("data_collector",0);
        assertThat(cpuMetric.size()).isEqualTo(2);
        assertThat(cpuMetric.get(0).getContainerId()).isEqualTo("data_collector");
        assertThat(cpuMetric.get(0).getUserSpacePercents()).isEqualTo(1192);
    }
    @Test
    public void cpuNotFindTest(){
        List<Cpu> cpuMetric =  cpuRepository.findByContainerAndTime("openzipkin/zipkin",0);
        assertThat(cpuMetric.size()).isEqualTo(0);
    }
}

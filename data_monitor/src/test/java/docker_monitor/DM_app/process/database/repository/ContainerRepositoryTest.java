package docker_monitor.DM_app.process.database.repository;


import docker_monitor.DM_app.process.database.db_source.DataSource;
import docker_monitor.DM_app.process.database.entities.Container;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.context.jdbc.Sql;

import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.util.List;
import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;


@TestPropertySource(locations= "classpath:defaultTest.properties")
@SpringBootTest
@ContextConfiguration(classes = DatabaseTestConfiguration.class)
@Sql("classpath:schema.sql")
@Sql("classpath:import.sql")
public class ContainerRepositoryTest {
    @Autowired
    private ContainerRepository containerRepository;

    @Test
    public void containerParsingTest(){
        List<Container> containers = containerRepository.findAll();
        assertThat(containers.size()).isEqualTo(3);
        assertThat(containers.get(0).getDockerID()).isEqualTo("0264d2962ddb8f8c8dd4d3a1ad759307b133e048dcf0784e7441060f53bcb8cc");
        assertThat(containers.get(0).getId()).isEqualTo("data_collector");
        assertThat(containers.get(0).getImage()).isEqualTo("data_collector");
        assertThat(containers.get(0).getName()).isEqualTo("/collector,");
    }
}

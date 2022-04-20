package docker_monitor.DM_app.process.database.repository;

import docker_monitor.DM_app.process.database.db_source.DataSource;
import docker_monitor.DM_app.process.database.db_source.DataSourceImp;
import org.springframework.boot.test.context.TestConfiguration;
import org.springframework.context.annotation.Bean;

@TestConfiguration
public class DatabaseTestConfiguration {
    @Bean
    public DataSource getDataSource(){
        return DataSourceImp.getInstance(
                "sa",
                "password",
                "disable",
                "jdbc:h2:mem:testdb",
                15);
    }
}

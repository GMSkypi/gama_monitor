package docker_monitor.DM_app.configuration;

import docker_monitor.DM_app.process.database.db_source.DataSource;
import docker_monitor.DM_app.process.database.db_source.DataSourceImp;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class DataSourceConfiguration {
    @Bean
    public DataSource getDataSource(){
        return DataSourceImp.getInstance("admin", "quest", "disable", "jdbc:postgresql://localhost:8812/qdb", 15);
    }
}

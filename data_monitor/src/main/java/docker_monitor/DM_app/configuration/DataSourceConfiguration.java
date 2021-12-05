package docker_monitor.DM_app.configuration;

import docker_monitor.DM_app.process.database.db_source.DataSource;
import docker_monitor.DM_app.process.database.db_source.DataSourceImp;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;
import org.springframework.core.env.Environment;


@Configuration
@PropertySource("classpath:application.properties")
public class DataSourceConfiguration {
    @Autowired
    private Environment env;

    @Bean
    public DataSource getDataSource(){
        return DataSourceImp.getInstance(
                env.getProperty("spring.datasource.username"),
                env.getProperty("spring.datasource.password"),
                env.getProperty("spring.datasource.sslmode"),
                env.getProperty("spring.datasource.jdbc-url"),
                15);
    }
}

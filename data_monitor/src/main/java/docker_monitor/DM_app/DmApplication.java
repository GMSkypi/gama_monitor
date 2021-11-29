package docker_monitor.DM_app;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.data.jpa.JpaRepositoriesAutoConfiguration;
import org.springframework.boot.autoconfigure.orm.jpa.HibernateJpaAutoConfiguration;


@SpringBootApplication
public class DmApplication {
    public static void main(String[] args) {
        SpringApplication.run(docker_monitor.DM_app.DmApplication.class, args);
    }
}

package docker_monitor.DM_app.configuration;

import docker_monitor.DM_app.process.notification_message_handler.NotificationObservers;
import docker_monitor.DM_app.process.notification_message_handler.SlackHandler;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@Configuration
public class BeanConfig {
    @Bean
    public PasswordEncoder getPasswordEncoder(){
        return new BCryptPasswordEncoder();
    }

    @Bean
    public List<NotificationObservers> getObservers(){
        return new ArrayList<>(List.of(new SlackHandler()));
    }
}

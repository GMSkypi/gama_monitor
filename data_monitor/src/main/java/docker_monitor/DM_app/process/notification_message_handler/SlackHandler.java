package docker_monitor.DM_app.process.notification_message_handler;

import com.github.seratch.jslack.Slack;
import com.github.seratch.jslack.api.webhook.Payload;
import com.github.seratch.jslack.api.webhook.WebhookResponse;
import docker_monitor.DM_app.process.service.cache.ConfigurationCache;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;

import java.io.IOException;

@Component
public class SlackHandler implements NotificationObservers{

    @Value("${slack.webhook}")
    private String urlSlackWebHook;

    @Value("${notification.enabled}")
    private boolean notify;

    @Autowired
    private ConfigurationCache configurationCache;

    @Override
    public void update(String message) {
        StringBuilder messageBuilder = new StringBuilder();
        messageBuilder.append("-------------------------" + "\n");
        messageBuilder.append("-- DOCKER MONITORING --" + "\n");
        messageBuilder.append(message);
        messageBuilder.append("-------------------------" + "\n");
        if(configurationCache.isNotify())
            process(messageBuilder.toString());
    }
    private void process(String message) {
        Payload payload = Payload.builder()
                .text(message)
                .build();
        try {
            WebhookResponse webhookResponse = Slack.getInstance().send(
                    configurationCache.getUrlSlackWebHook(), payload);
            // TODO logger
        } catch (IOException e) {
            System.out.println(e);
        }
    }
}

package docker_monitor.DM_app.web.dto;

public class SlackConfDTO {
    private String slackWebhook;
    private boolean active;

    public SlackConfDTO(String slackWebhook, boolean active) {
        this.slackWebhook = slackWebhook;
        this.active = active;
    }

    public String getSlackWebhook() {
        return slackWebhook;
    }

    public void setSlackWebhook(String slackWebhook) {
        this.slackWebhook = slackWebhook;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean active) {
        this.active = active;
    }
}

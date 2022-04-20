package docker_monitor.DM_app.process.object.notification;


public class ThresholdNotify {
    Trigger trigger;
    Threshold threshold;

    public ThresholdNotify(Trigger trigger, Threshold thrashold) {
        this.trigger = trigger;
        this.threshold = thrashold;
    }
    public ThresholdNotify(){}

    public Trigger getTrigger() {
        return trigger;
    }

    public void setTrigger(Trigger trigger) {
        this.trigger = trigger;
    }

    public Threshold getThreshold() {
        return threshold;
    }

    public void setThreshold(Threshold threshold) {
        this.threshold = threshold;
    }
}

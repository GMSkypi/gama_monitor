package docker_monitor.DM_app.process.object;


public class ThresholdNotify {
    Trigger trigger;
    Threshold thrashold;

    public ThresholdNotify(Trigger trigger, Threshold thrashold) {
        this.trigger = trigger;
        this.thrashold = thrashold;
    }
    public ThresholdNotify(){}

    public Trigger getTrigger() {
        return trigger;
    }

    public void setTrigger(Trigger trigger) {
        this.trigger = trigger;
    }

    public Threshold getThrashold() {
        return thrashold;
    }

    public void setThrashold(Threshold thrashold) {
        this.thrashold = thrashold;
    }
}

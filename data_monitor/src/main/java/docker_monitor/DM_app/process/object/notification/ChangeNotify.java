package docker_monitor.DM_app.process.object.notification;

public class ChangeNotify {
    Trigger trigger;
    long comparedToBefore;

    public ChangeNotify(Trigger trigger, long comparedToBefore) {
        this.trigger = trigger;
        this.comparedToBefore = comparedToBefore;
    }
    public ChangeNotify(){}

    public Trigger getTrigger() {
        return trigger;
    }

    public void setTrigger(Trigger trigger) {
        this.trigger = trigger;
    }

    public long getComparedToBefore() {
        return comparedToBefore;
    }

    public void setComparedToBefore(long comparedToBefore) {
        this.comparedToBefore = comparedToBefore;
    }
}

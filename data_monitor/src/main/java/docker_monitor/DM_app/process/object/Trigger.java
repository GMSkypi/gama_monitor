package docker_monitor.DM_app.process.object;

public enum Trigger {
    ABOVE("above"),
    BELOW("below");

    private final String val;

    Trigger(String val) {
        this.val = val;
    }
    @Override
    public String toString() {
        return val;
    }
}

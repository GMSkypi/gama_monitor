package docker_monitor.DM_app.process.object;

public enum Threshold {
    AVERAGE("average"),
    MIN("min"),
    MAX("max"),
    MEDIAN("median");

    private final String val;

    Threshold(String val) {
        this.val = val;
    }
    @Override
    public String toString() {
        return val;
    }
}

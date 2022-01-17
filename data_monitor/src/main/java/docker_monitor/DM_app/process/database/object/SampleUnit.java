package docker_monitor.DM_app.process.database.object;

public enum SampleUnit {
    MILLI("T"),
    SEC("s"),
    MIN("m"),
    HOUR("h"),
    DAY("d"),
    MONTH("M");

    private final String val;

    SampleUnit(String val) {
        this.val = val;
    }
    @Override
    public String toString() {
        return val;
    }
}

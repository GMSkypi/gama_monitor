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

    public static SampleUnit fromLetter(String letter) {
        for (SampleUnit s : values() ){
            if (s.val.equals(letter)) return s;
        }
        return null;
    }
    @Override
    public String toString() {
        return val;
    }
}

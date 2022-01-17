package docker_monitor.DM_app.process.database.object;

public class SampledBy {
    private int value;
    private SampleUnit unit;

    public SampledBy(int value, SampleUnit unit){
        this.value = value;
        this.unit = unit;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }

    public SampleUnit getUnit() {
        return unit;
    }

    public void setUnit(SampleUnit unit) {
        this.unit = unit;
    }

    @Override
    public String toString() {
        return unit.toString() + value;
    }
}

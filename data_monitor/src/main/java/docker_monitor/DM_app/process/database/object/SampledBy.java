package docker_monitor.DM_app.process.database.object;

public class SampledBy {
    private int value;
    private SampleUnit unit;

    public SampledBy(String data){
        if(data.length() > 0){
            unit = SampleUnit.fromLetter(data.charAt(data.length() - 1) + "");
            value = Integer.parseInt(data.substring(0, data.length() - 1));
        }
    }
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
        return  value + unit.toString();
    }
}

package docker_monitor.DM_app.process.object;

import java.time.Instant;
import java.util.Date;

public class Metric {
    long value;
    Instant dateTime;

    public Metric(long value, Instant dateTime) {
        this.value = value;
        this.dateTime = dateTime;
    }

    public long getValue() {
        return value;
    }

    public void setValue(long value) {
        this.value = value;
    }

    public Instant getDateTime() {
        return dateTime;
    }

    public void setDateTime(Instant dateTime) {
        this.dateTime = dateTime;
    }
}

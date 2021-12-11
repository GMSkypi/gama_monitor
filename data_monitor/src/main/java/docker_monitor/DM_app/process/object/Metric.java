package docker_monitor.DM_app.process.object;

import java.util.Date;

public class Metric {
    long value;
    Date dateTime;

    public Metric(long value, Date dateTime) {
        this.value = value;
        this.dateTime = dateTime;
    }

    public long getValue() {
        return value;
    }

    public void setValue(long value) {
        this.value = value;
    }

    public Date getDateTime() {
        return dateTime;
    }

    public void setDateTime(Date dateTime) {
        this.dateTime = dateTime;
    }
}

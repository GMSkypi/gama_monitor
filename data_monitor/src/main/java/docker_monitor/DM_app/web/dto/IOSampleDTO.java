package docker_monitor.DM_app.web.dto;

import java.time.Instant;

public class IOSampleDTO {
    private long byteRead;
    private long byteWrite;
    private Instant dateTime;

    public long getByteRead() {
        return byteRead;
    }

    public void setByteRead(long byteRead) {
        this.byteRead = byteRead;
    }

    public long getByteWrite() {
        return byteWrite;
    }

    public void setByteWrite(long byteWrite) {
        this.byteWrite = byteWrite;
    }

    public Instant getDateTime() {
        return dateTime;
    }

    public void setDateTime(Instant dateTime) {
        this.dateTime = dateTime;
    }
}

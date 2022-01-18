package docker_monitor.DM_app.process.database.entities;

import docker_monitor.DM_app.process.database.persistance.anotation.Aggregable;
import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.anotation.Symbol;

import java.time.Instant;
import java.util.Date;

@Entity(name = "IO")
public class IO {
    @Symbol
    @Column(name = "Container_id")
    String containerId;
    @Aggregable
    @Column(name = "read")
    long byteRead;
    @Aggregable
    @Column(name = "write")
    long byteWrite;
    @Column(name = "date_time")
    Instant dateTime;

    public String getContainerId() {
        return containerId;
    }

    public void setContainerId(String containerId) {
        this.containerId = containerId;
    }

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

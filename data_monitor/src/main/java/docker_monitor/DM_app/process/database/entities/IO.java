package docker_monitor.DM_app.process.database.entities;

import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.anotation.Symbol;

import java.sql.Date;

@Entity(name = "IO")
public class IO {
    @Symbol
    @Column(name = "Container_id")
    String containerId;
    @Column(name = "read")
    long byteRead;
    @Column(name = "write")
    long byteWrite;
    @Column(name = "date_time")
    Date date;

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

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}

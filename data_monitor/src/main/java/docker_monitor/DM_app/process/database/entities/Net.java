package docker_monitor.DM_app.process.database.entities;

import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.anotation.Symbol;

import java.sql.Date;

@Entity(name = "NET")
public class Net {
    @Symbol
    @Column(name = "ContainerId")
    String containerId;
    @Column(name = "receive")
    long receive;
    @Column(name = "receive_error")
    long receiveErrorCountPeriod;
    @Column(name = "receive_error_total")
    long receiveErrorCountTotal;
    @Column(name = "transmit")
    long transmit;
    @Column(name = "transmit_error")
    long transmitErrorCountPeriod;
    @Column(name = "transmit_error_total")
    long transmitErrorCountTotal;
    @Column(name = "date_time")
    Date date;

    public String getContainerId() {
        return containerId;
    }

    public void setContainerId(String containerId) {
        this.containerId = containerId;
    }

    public long getReceive() {
        return receive;
    }

    public void setReceive(long receive) {
        this.receive = receive;
    }

    public long getReceiveErrorCountPeriod() {
        return receiveErrorCountPeriod;
    }

    public void setReceiveErrorCountPeriod(long receiveErrorCountPeriod) {
        this.receiveErrorCountPeriod = receiveErrorCountPeriod;
    }

    public long getReceiveErrorCountTotal() {
        return receiveErrorCountTotal;
    }

    public void setReceiveErrorCountTotal(long receiveErrorCountTotal) {
        this.receiveErrorCountTotal = receiveErrorCountTotal;
    }

    public long getTransmit() {
        return transmit;
    }

    public void setTransmit(long transmit) {
        this.transmit = transmit;
    }

    public long getTransmitErrorCountPeriod() {
        return transmitErrorCountPeriod;
    }

    public void setTransmitErrorCountPeriod(long transmitErrorCountPeriod) {
        this.transmitErrorCountPeriod = transmitErrorCountPeriod;
    }

    public long getTransmitErrorCountTotal() {
        return transmitErrorCountTotal;
    }

    public void setTransmitErrorCountTotal(long transmitErrorCountTotal) {
        this.transmitErrorCountTotal = transmitErrorCountTotal;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}
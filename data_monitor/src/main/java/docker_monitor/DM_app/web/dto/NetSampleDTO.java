package docker_monitor.DM_app.web.dto;
import java.time.Instant;

public class NetSampleDTO {
    private long receive;
    private long receiveErrorCountPeriod;
    private long receiveErrorCountTotal;
    private long transmit;
    private long transmitErrorCountPeriod;
    private long transmitErrorCountTotal;
    private Instant dateTime;

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

    public Instant getDateTime() {
        return dateTime;
    }

    public void setDateTime(Instant dateTime) {
        this.dateTime = dateTime;
    }
}

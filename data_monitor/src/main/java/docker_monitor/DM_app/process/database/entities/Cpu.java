package docker_monitor.DM_app.process.database.entities;

import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.anotation.Symbol;

import java.sql.Date;

@Entity(name = "CPU")
public class Cpu {
    @Symbol
    @Column(name = "Container_id")
    String containerId;
    @Column(name = "u_space_pr")
    long userSpacePercents;
    @Column(name = "k_space_pr")
    long kernelSpacePercents;
    @Column(name = "u_space_ms")
    long userSpaceMs;
    @Column(name = "k_space_ms")
    long kernelSpaceMs;
    @Column(name = "throttle_ns")
    long throttleMs;
    @Column(name = "throttle_cnt")
    long throttleCount;
    @Column(name = "total_ns")
    long totalMs;
    @Column(name = "total_pr")
    long totalPercents;
    @Column(name = "date_time")
    Date DateTime;

    public String getContainerId() {
        return containerId;
    }

    public void setContainerId(String containerId) {
        this.containerId = containerId;
    }

    public long getUserSpacePercents() {
        return userSpacePercents;
    }

    public void setUserSpacePercents(long userSpacePercents) {
        this.userSpacePercents = userSpacePercents;
    }

    public long getKernelSpacePercents() {
        return kernelSpacePercents;
    }

    public void setKernelSpacePercents(long kernelSpacePercents) {
        this.kernelSpacePercents = kernelSpacePercents;
    }

    public long getUserSpaceMs() {
        return userSpaceMs;
    }

    public void setUserSpaceMs(long userSpaceMs) {
        this.userSpaceMs = userSpaceMs;
    }

    public long getKernelSpaceMs() {
        return kernelSpaceMs;
    }

    public void setKernelSpaceMs(long kernelSpaceMs) {
        this.kernelSpaceMs = kernelSpaceMs;
    }

    public long getThrottleMs() {
        return throttleMs;
    }

    public void setThrottleMs(long throttleMs) {
        this.throttleMs = throttleMs;
    }

    public long getThrottleCount() {
        return throttleCount;
    }

    public void setThrottleCount(long throttleCount) {
        this.throttleCount = throttleCount;
    }

    public long getTotalMs() {
        return totalMs;
    }

    public void setTotalMs(long totalMs) {
        this.totalMs = totalMs;
    }

    public long getTotalPercents() {
        return totalPercents;
    }

    public void setTotalPercents(long totalPercents) {
        this.totalPercents = totalPercents;
    }

    public Date getDateTime() {
        return DateTime;
    }

    public void setDateTime(Date dateTime) {
        DateTime = dateTime;
    }
}

package docker_monitor.DM_app.web.dto;

import java.time.Instant;

public class CpuSampleDTO {
    private long userSpacePercents;
    private long kernelSpacePercents;
    private long userSpaceMs;
    private long kernelSpaceMs;
    private long throttleMs;
    private long throttleCount;
    private long totalMs;
    private long totalPercents;
    private Instant dateTime;

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

    public Instant getDateTime() {
        return dateTime;
    }

    public void setDateTime(Instant dateTime) {
        this.dateTime = dateTime;
    }
}

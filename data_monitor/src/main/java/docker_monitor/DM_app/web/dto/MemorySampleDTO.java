package docker_monitor.DM_app.web.dto;

import java.time.Instant;

public class MemorySampleDTO {
    private long memoryUsed;
    private long memoryAndSwapUsed;
    private long rss;
    private long cache;
    private long swap;
    private long memoryLimit;
    private long memoryAndSwapLimit;
    private long memoryLimitHitCount;
    private long memoryAndSwapLimitHitCount;
    private Instant dateTime;

    public long getMemoryUsed() {
        return memoryUsed;
    }

    public void setMemoryUsed(long memoryUsed) {
        this.memoryUsed = memoryUsed;
    }

    public long getMemoryAndSwapUsed() {
        return memoryAndSwapUsed;
    }

    public void setMemoryAndSwapUsed(long memoryAndSwapUsed) {
        this.memoryAndSwapUsed = memoryAndSwapUsed;
    }

    public long getRss() {
        return rss;
    }

    public void setRss(long rss) {
        this.rss = rss;
    }

    public long getCache() {
        return cache;
    }

    public void setCache(long cache) {
        this.cache = cache;
    }

    public long getSwap() {
        return swap;
    }

    public void setSwap(long swap) {
        this.swap = swap;
    }

    public long getMemoryLimit() {
        return memoryLimit;
    }

    public void setMemoryLimit(long memoryLimit) {
        this.memoryLimit = memoryLimit;
    }

    public long getMemoryAndSwapLimit() {
        return memoryAndSwapLimit;
    }

    public void setMemoryAndSwapLimit(long memoryAndSwapLimit) {
        this.memoryAndSwapLimit = memoryAndSwapLimit;
    }

    public long getMemoryLimitHitCount() {
        return memoryLimitHitCount;
    }

    public void setMemoryLimitHitCount(long memoryLimitHitCount) {
        this.memoryLimitHitCount = memoryLimitHitCount;
    }

    public long getMemoryAndSwapLimitHitCount() {
        return memoryAndSwapLimitHitCount;
    }

    public void setMemoryAndSwapLimitHitCount(long memoryAndSwapLimitHitCount) {
        this.memoryAndSwapLimitHitCount = memoryAndSwapLimitHitCount;
    }

    public Instant getDateTime() {
        return dateTime;
    }

    public void setDateTime(Instant dateTime) {
        this.dateTime = dateTime;
    }
}

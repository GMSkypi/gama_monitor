package docker_monitor.DM_app.process.database.entities;

import docker_monitor.DM_app.process.database.persistance.anotation.Column;
import docker_monitor.DM_app.process.database.persistance.anotation.Entity;
import docker_monitor.DM_app.process.database.persistance.anotation.Symbol;

import java.sql.Date;

@Entity(name = "Memory")
public class Memory {
    @Symbol
    @Column(name = "Container_id")
    String containerId;
    @Column(name = "mem_used")
    long memoryUsed;
    @Column(name = "mem_swap_used")
    long memoryAndSwapUsed;
    @Column(name = "rss")
    long rss;
    @Column(name = "cacheC")
    long cache;
    @Column(name = "swap")
    long swap;
    @Column(name = "mem_limit")
    long memoryLimit;
    @Column(name = "mem_swap_limit")
    long memoryAndSwapLimit;
    @Column(name = "mem_hit_cnt")
    long memoryLimitHitCount;
    @Column(name = "mem_swap_hit_cnt")
    long memoryAndSwapLimitHitCount;
    @Column(name = "date_time")
    Date date;

    public String getContainerId() {
        return containerId;
    }

    public void setContainerId(String containerId) {
        this.containerId = containerId;
    }

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

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}


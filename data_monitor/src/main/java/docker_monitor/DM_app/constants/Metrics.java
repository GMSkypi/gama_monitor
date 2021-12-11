package docker_monitor.DM_app.constants;


public enum Metrics {
    U_SPACE_PR("userSpacePercents"),
    K_SPACE_PR("kernelSpacePercents"),
    U_SPACE_MS("userSpaceMs"),
    K_SPACE_MS("kernelSpaceMs"),
    THROTTLE_NS("throttleMs"),
    THROTTLE_CNT("throttleCount"),
    TOTAL_NS("totalMs"),
    TOTAL_PR("totalPercents"),

    READ("byteRead"),
    WRITE("byteWrite"),

    MEM_USED("memoryUsed"),
    MEM_SWAP_USED("memoryAndSwapUsed"),
    RSS("rss"),
    CACHE_C("cache"),
    SWAP("swap"),
    MEM_LIMIT("memoryLimit"),
    MEM_SWAP_LIMIT("memoryAndSwapLimit"),
    MEM_HIT_CNT("memoryLimitHitCount"),
    MEM_SWAP_HIT_CNT("memoryAndSwapLimitHitCount"),

    RECEIVE("receive"),
    RECEIVE_ERROR("receiveErrorCountPeriod"),
    RECEIVE_ERROR_TOTAL("receiveErrorCountTotal"),
    TRANSMIT("transmit"),
    TRANSMIT_ERROR("transmitErrorCountPeriod"),
    TRANSMIT_ERROR_TOTAL("transmitErrorCountTotal");

    private final String val;

    Metrics(String val) {
        this.val = val;
    }
    @Override
    public String toString() {
        return val;
    }
}

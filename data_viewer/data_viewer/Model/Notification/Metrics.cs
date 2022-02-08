using System;

namespace data_viewer.Model.Notification
{
    public enum Metrics
    {
        U_SPACE_PR,
        K_SPACE_PR,
        U_SPACE_MS,
        K_SPACE_MS,
        THROTTLE_NS,
        THROTTLE_CNT,
        TOTAL_NS,
        TOTAL_PR,

        READ,
        WRITE,

        MEM_USED,
        MEM_SWAP_USED,
        RSS,
        CACHE_C,
        SWAP,
        MEM_LIMIT,
        MEM_SWAP_LIMIT,
        MEM_HIT_CNT,
        MEM_SWAP_HIT_CNT,

        RECEIVE,
        RECEIVE_ERROR,
        RECEIVE_ERROR_TOTAL,
        TRANSMIT,
        TRANSMIT_ERROR,
        TRANSMIT_ERROR_TOTAL;
    }
}
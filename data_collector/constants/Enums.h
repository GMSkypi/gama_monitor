//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_ENUMS_H
#define DATA_COLLECTOR_ENUMS_H

namespace constants{
    enum Metrics{
        CPU_USER,
        CPU_USER_ACUM,
        CPU_KERNEL,
        CPU_KERNEL_ACUM,
        THROTTLE_TIME,
        THROTTLE_COUNT,

        MEM_USED,
        MEM_USED_SWAP,
        MEM_RSS,
        MEM_CACHE,
        MEM_SWAP,
        MEM_FREE,
        MEM_LIMIT,
        MEM_SWAP_LIMIT,
        MEM_SWAP_FREE,
        MEM_HIT_COUNT,
        MEM_SWAP_HIT_COUNT,

        IO_READ_ACC,
        IO_READ,
        IO_WRITE_ACC,
        IO_WRITE,

        NET_RECEIVE_ACC,
        NET_RECEIVE,
        NET_RECEIVE_ERROR_ACC,
        NET_RECEIVE_ERROR,

        NET_TRANSMIT_ACC,
        NET_TRANSMIT,
        NET_TRANSMIT_ERROR_ACC,
        NET_TRANSMIT_ERROR,
    };

    enum Paths{
        CPU_USAGE,
        CPU_THROTTLE,
        CPU_TOTAL,
        CPU_PROC_TOTAL,
        MEM,
        MEM_TOTAL,
        MEM_TOTAL_SWAP,
        MEM_LIMITS,
        MEM_LIMIT_SWAP,
        MEM_COUNT_LIMHIT,
        MEM_SWAP_LIMHIT,
        IO,
        NET,
    };

    enum OS{
        WINDOWS,
        LINUX,
        APPLE,
        UNIX,
        POSIX,
        UNKNOWN,
    };
}


#endif //DATA_COLLECTOR_ENUMS_H

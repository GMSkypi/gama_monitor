//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_ENUMS_H
#define DATA_COLLECTOR_ENUMS_H

namespace constants{
    namespace metrics{
        enum Metrics{
            // https://docs.fedoraproject.org/en-US/Fedora/15/html/Resource_Management_Guide/sec-cpuacct.html
            CPU_USER, // % period * 1000
            CPU_USER_TIME, //period in USER_HZ
            CPU_USER_ACUM, // total in USER_HZ
            CPU_KERNEL, // % period
            CPU_KERNEL_TIME, // period in USER_HZ
            CPU_TOTAL_ACUM, // total in USER_HZ of seconds
            CPU_TOTAL, //  total in USER_HZ of seconds
            CPU_KERNEL_ACUM, // total in nanoseconds
            THROTTLE_TIME, // total in nanoseconds
            THROTTLE_COUNT, // total count
            CPU_PROC_TOTAL, // total nanoseconds
            CPU_PROC, // % period
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
    }


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

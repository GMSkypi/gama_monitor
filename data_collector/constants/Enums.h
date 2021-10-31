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
            CPU_USER_TIME, //period in millisecond
            CPU_USER_ACUM, // total in USER_HZ
            CPU_KERNEL, // % period
            CPU_KERNEL_TIME, // period in millisecond
            CPU_TOTAL_ACUM, // total in USER_HZ of seconds
            CPU_TOTAL, //  total in USER_HZ of seconds
            CPU_KERNEL_ACUM, // total in nanoseconds
            THROTTLE_TIME, // total in nanoseconds
            THROTTLE_COUNT, // total count
            CPU_PROC_TOTAL, // total nanoseconds
            CPU_PROC, // % period
            MEM_USED, // in bytes
            MEM_USED_SWAP, // in bytes
            MEM_RSS, // bytes of anonymous and swap cache memory
            MEM_CACHE, // bytes of page cache memory
            MEM_SWAP, // of bytes of swap usage
            MEM_FREE,
            MEM_LIMIT, // bytes of memory limit
            MEM_SWAP_LIMIT, // bytes of memory+swap limit
            MEM_SWAP_FREE,
            MEM_HIT_COUNT, // show the number of memory usage hits limits
            MEM_SWAP_HIT_COUNT, // show the number of memory+Swap hits limits

            IO_READ_ACC, // bytes total
            IO_READ, // period bytes
            IO_WRITE_ACC, // bytes total
            IO_WRITE, // period bytes

            NET_RECEIVE_ACC, // bytes total
            NET_RECEIVE, // period bytes
            NET_RECEIVE_ERROR_ACC, // count total
            NET_RECEIVE_ERROR, // period count

            NET_TRANSMIT_ACC, // bytes total
            NET_TRANSMIT, // period bytes
            NET_TRANSMIT_ERROR_ACC, // count total
            NET_TRANSMIT_ERROR, // period count
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

    enum Actions{
        EXPLORE_NEW,
        CAPTURE,
    };
}


#endif //DATA_COLLECTOR_ENUMS_H

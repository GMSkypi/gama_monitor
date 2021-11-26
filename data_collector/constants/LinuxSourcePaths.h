//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_LINUXSOURCEPATHS_H
#define DATA_COLLECTOR_LINUXSOURCEPATHS_H
namespace linuxSourcePaths{
    const string cqroupPath = "/sys/fs/cgroup/";

    const string accCPUPath = "cpuacct/docker/";
    const string cpuUsageFile = "cpuacct.stat";
    const string cpuPath = "cpu/docker/";
    const string cpuThrottleFile = "cpu.stat";
    const string totalCPUUsagePath = "/proc/stat";
    const string processTotalCPUFile = "cpuacct.usage";

    const string memPath = "memory/docker/";
    const string memStatFile = "memory.stat";
    const string totalMemFile = "memory.usage_in_bytes";
    const string totalMemSwapFile = "memory.memsw.usage_in_bytes";
    const string memoryLimitFile = "memory.limit_in_bytes";
    const string memorySwapLimitFile = "memory.memsw.limit_in_bytes";
    const string memLimitHitFile = "memory.failcnt";
    const string memSwLimitHitFile = "memory.memsw.failcnt";

    const string ioPath = "blkio/docker/";
    const string ioFile = "blkio.throttle.io_service_bytes";

    const string pidsPath = "pids/docker";
    const string pidsFile = "task";
    const string proc = "/proc/";
    const string networkTrafficFile = "net/dev";

    const string iniPath = "../config/config.ini";
    const string questDBcsPath = "../config/questDB-create-script.sql";
}


#endif //DATA_COLLECTOR_LINUXSOURCEPATHS_H

//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_LINUXSOURCEPATHS_H
#define DATA_COLLECTOR_LINUXSOURCEPATHS_H

static const string cqroupPath = "/sys/fs/cgroup/";

static const string accCPUPath = "cpuacct/docker/";
static const string cpuUsageFile = "cpuacct.stat";
static const string cpuPath = "cpu/docker/";
static const string cpuThrottleFile = "cpu.stat";
static const string totalCPUUsagePath = "/proc/stat";
static const string processTotalCPUFile = "cpuacct.usage";

static const string memPath = "memory/docker/";
static const string memStatFile = "memory.stat";
static const string totalMemFile = "memory.usage_in_bytes";
static const string totalMemSwapFile = "memory.memsw.usage_in_bytes";
static const string memoryLimitFile = "memory.limit_in_bytes";
static const string memorySwapLimitFile = "hierarchical_memsw_limit";
static const string memLimitHitFile = "memory.failcnt";
static const string memSwLimitHitFile = "memory.memsw.failcnt";

static const string ioPath = "blkio/docker/";
static const string ioFile = "blkio.throttle.io_service_bytes";

static const string pidsPath = "pids/docker";
static const string pidsFile = "task";
static const string proc = "/proc/";
static const string networkTrafficFile = "net/dev"

#endif //DATA_COLLECTOR_LINUXSOURCEPATHS_H

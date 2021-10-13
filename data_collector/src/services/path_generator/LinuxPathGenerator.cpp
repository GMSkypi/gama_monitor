//
// Created by gama on 06.10.21.
//

#include "LinuxPathGenerator.h"
#include "../../../constants/LinuxSourcePaths.h"
;
string LinuxPathGenerator::getCPUUsagePath(string containerId) {
    return cqroupPath + accCPUPath + containerId + "/" +   cpuUsageFile;
}

string LinuxPathGenerator::getCPUThrottlePath(string containerId) {
    return cqroupPath + cpuPath + containerId + "/" + cpuThrottleFile;
}

string LinuxPathGenerator::getCPUTotalPath() {
    return totalCPUUsagePath;
}

string LinuxPathGenerator::getCPUProcTotalPath(string containerId) {
    return cqroupPath + accCPUPath + containerId + "/" + processTotalCPUFile;
}

string LinuxPathGenerator::getMemoryPath(string containerId) {
    return cqroupPath + memPath +containerId + "/" + memStatFile;
}

string LinuxPathGenerator::getTotalMemPath(string containerId) {
    return cqroupPath + memPath + containerId + "/" + totalMemFile;
}

string LinuxPathGenerator::getTotalSwapMemPath(string containerId) {
    return cqroupPath + memPath + containerId + "/" + totalMemSwapFile;
}

string LinuxPathGenerator::getMemLimitsPath(string containerId) {
    return cqroupPath + memPath + containerId + "/" + memoryLimitFile;
}

string LinuxPathGenerator::getMemSwapLimitsPath(string containerId) {
    return cqroupPath + memPath + containerId + "/" + memorySwapLimitFile;
}

string LinuxPathGenerator::getMemHitCountPath(string containerId) {
    return cqroupPath + memPath + containerId + "/" + memLimitHitFile;
}

string LinuxPathGenerator::getMemSwapHitCountPath(string containerId) {
    return cqroupPath + memPath + containerId + "/" + memSwLimitHitFile;
}

string LinuxPathGenerator::getIOPath(string containerId) {
    return cqroupPath + ioPath + containerId + "/" + ioFile;
}

string LinuxPathGenerator::getNetworkPath(unsigned int containerPid) {
    return proc + to_string(containerPid) + "/" + networkTrafficFile;
}

string LinuxPathGenerator::getPidPath(string containerId) {
    return cqroupPath + pidsPath + containerId + "/" + pidsFile;
}

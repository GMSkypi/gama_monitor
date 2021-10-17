//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_LINUXPATHGENERATOR_H
#define DATA_COLLECTOR_LINUXPATHGENERATOR_H


#include "PathGenerator.h"
#include "string"
#include "../../../constants/LinuxSourcePaths.h"

using namespace linuxSourcePaths;

class LinuxPathGenerator : public PathGenerator {
public:
    string getCPUUsagePath(string containerId) override;

    string getCPUThrottlePath(string containerId) override;

    string getCPUTotalPath() override;

    string getCPUProcTotalPath(string containerId) override;

    string getMemoryPath(string containerId) override;

    ~LinuxPathGenerator();

    string getTotalMemPath(string containerId) override;

    string getTotalSwapMemPath(string containerId) override;

    string getMemLimitsPath(string containerId) override;

    string getMemSwapLimitsPath(string containerId) override;

    string getMemHitCountPath(string containerId) override;

    string getMemSwapHitCountPath(string containerId) override;

    string getIOPath(string containerId) override;

    string getNetworkPath(unsigned int containerPid) override;

    string getPidPath(string containerId) override;
};


#endif //DATA_COLLECTOR_LINUXPATHGENERATOR_H

//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_PATHGENERATOR_H
#define DATA_COLLECTOR_PATHGENERATOR_H
#include <string>
using namespace std;

class PathGenerator{
    virtual string getCPUUsagePath(string containerId) = 0;
    virtual string getCPUThrottlePath(string containerId) = 0;
    virtual string getCPUTotalPath() = 0;
    virtual string getCPUProcTotalPath(string containerId) = 0;
    virtual string getMemoryPath(string containerId) = 0;
    virtual string getTotalMemPath(string containerId) = 0;
    virtual string getTotalSwapMemPath(string containerId) = 0;
    virtual string getMemLimitsPath(string containerId) = 0;
    virtual string getMemSwapLimitsPath(string containerId) = 0;
    virtual string getMemHitCountPath(string containerId) = 0;
    virtual string getMemSwapHitCountPath(string containerId) = 0;
    virtual string getIOPath(string containerId) = 0;
    virtual string getNetworkPath(unsigned containerPid) = 0;
    virtual string getPidPath(string containerId) = 0;
};
#endif //DATA_COLLECTOR_PATHGENERATOR_H

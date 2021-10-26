//
// Created by gama on 26.10.21.
//

#ifndef DATA_COLLECTOR_TIMER_H
#define DATA_COLLECTOR_TIMER_H

#include <chrono>
#include "../obj/Config.h"
#include "../../constants/Enums.h"
using namespace std::chrono;

class Timer {
private:
    steady_clock::time_point exploreNewTimePoint;
    steady_clock::time_point metricCaptureTimePoint;
    std::shared_ptr<Config> conf;
    std::chrono::steady_clock::time_point startTimePoint;
    std::vector<constants::Actions> actions;
public:
    Timer(std::shared_ptr<Config> conf);
    const std::vector<constants::Actions> * getActions();
    unsigned sleepFor();
};


#endif //DATA_COLLECTOR_TIMER_H

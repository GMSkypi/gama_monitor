//
// Created by gama on 26.10.21.
//

#include "Timer.h"

Timer::Timer(std::shared_ptr<Config> conf) {
    this->conf = conf;
    exploreNewTimePoint = std::chrono::steady_clock::now() +
            std::chrono::milliseconds(conf->exploreDelay);
     metricCaptureTimePoint = std::chrono::steady_clock::now();
}

const std::vector<constants::Actions> * Timer::getActions() {
    startTimePoint = std::chrono::steady_clock::now();

    if(std::chrono::duration_cast<std::chrono::milliseconds>(exploreNewTimePoint - startTimePoint).count() - 50 <=0){
        actions.push_back(constants::Actions::EXPLORE_NEW);
    }
    if(std::chrono::duration_cast<std::chrono::milliseconds>(metricCaptureTimePoint - startTimePoint).count() -50  <= 0){
        actions.push_back(constants::Actions::CAPTURE);
    }
    return &actions;
}

unsigned Timer::sleepFor() {
    for(constants::Actions action : actions){
        switch(action){
            case constants::Actions::CAPTURE:
                metricCaptureTimePoint = std::chrono::steady_clock::now() + std::chrono::milliseconds(conf->metricDelay);
                continue;
            case constants::Actions::EXPLORE_NEW:
                exploreNewTimePoint = std::chrono::steady_clock::now() + std::chrono::milliseconds(conf->exploreDelay);
                continue;
        }
    }
    actions = std::vector<constants::Actions>();
    std::chrono::steady_clock::time_point endTimePoint = std::chrono::steady_clock::now();
    if(exploreNewTimePoint > metricCaptureTimePoint){
        return std::chrono::duration_cast<std::chrono::milliseconds>(metricCaptureTimePoint - endTimePoint).count();

    }
    return std::chrono::duration_cast<std::chrono::milliseconds>(exploreNewTimePoint - endTimePoint).count();
}

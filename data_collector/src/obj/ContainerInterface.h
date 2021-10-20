//
// Created by gama on 20.10.21.
//

#ifndef DATA_COLLECTOR_CONTAINERINTERFACE_H
#define DATA_COLLECTOR_CONTAINERINTERFACE_H


#include <string>
#include <map>
#include "../../constants/Enums.h"

class ContainerInterface {
private:
    std::string name;
    std::map<constants::metrics::Metrics,unsigned> lastMetrics;
};


#endif //DATA_COLLECTOR_CONTAINERINTERFACE_H

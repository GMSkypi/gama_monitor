//
// Created by gama on 14.10.21.
//

#ifndef DATA_COLLECTOR_METRICPARSER_H
#define DATA_COLLECTOR_METRICPARSER_H


#include "string"
#include "map"
#include "../../../constants/Enums.h"

namespace metricParser{
    class MetricParser{
    public:
        virtual void parse(const std::string & data,
                           std::map<constants::Metrics,unsigned> & metrics) = 0;
    };

}
//std::map<constants::Metrics,unsigned>
#endif //DATA_COLLECTOR_METRICPARSER_H

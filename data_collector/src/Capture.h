//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_CAPTURE_H
#define DATA_COLLECTOR_CAPTURE_H


#include "obj/Container.h"
#include "parsers/metric_parsers/MetricParser.h"
#include "vector"
#include "services/MetricsParserFactory.h"

class Capture {
public:
    void newCapture(Container & container,std::vector<MetricsParserFactory::metricParserVP> unCapturedMetrics);
private:

};
// TODO accept paths

#endif //DATA_COLLECTOR_CAPTURE_H

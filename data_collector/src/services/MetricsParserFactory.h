//
// Created by gama on 14.10.21.
//

#ifndef DATA_COLLECTOR_METRICSPARSERFACTORY_H
#define DATA_COLLECTOR_METRICSPARSERFACTORY_H
#include <vector>
#include <utility>
#include <memory>
#include "../../constants/Enums.h"
#include "../parsers/metric_parsers/MetricParser.h"

using namespace metricParser;

class MetricsParserFactory {
public:
    struct metricParserVP{
        constants::Paths path;
        std::shared_ptr<MetricParser> parser;
    };

private:
    std::vector<metricParserVP> metricSources;
public:

    void addCPUUsage(); // CPU total
    void addCPUThrottle(); // CPU total
    void addCPUProcTotal();
    void addMemory();
    void addMemoryTotal();
    void addMemorySwap();
    void addMemoryLimit();
    void addMemoryLimitSwap();
    void addLimitHit();
    void addLimitSwapHit();
    void addNetwork();
    void addIO();
    void addCPUTotal();
    void addAllMetrics();
    void addAllGlobalMetrics();
    std::vector<metricParserVP> getMetricSources();
};


#endif //DATA_COLLECTOR_METRICSPARSERFACTORY_H

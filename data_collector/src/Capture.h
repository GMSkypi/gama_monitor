//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_CAPTURE_H
#define DATA_COLLECTOR_CAPTURE_H


#include "obj/Container.h"
#include "parsers/metric_parsers/MetricParser.h"
#include "vector"
#include "services/MetricsParserFactory.h"
#include "services/file_reader/FileReader.h"

using namespace constants::metrics;

class Capture {
private:
    std::vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics;
    std::map<constants::Paths,std::string> globalPaths;
    std::map<constants::metrics::Metrics,unsigned long> lastGlobalMetrics;
    std::shared_ptr<FileReader> fileReader;
public:
    Capture(std::vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics,
            std::map<constants::Paths,std::string> globalPaths,
            std::shared_ptr<FileReader> fileReader);
    void newCapture(Container & container,std::vector<MetricsParserFactory::metricParserVP> unCapturedMetrics);
    void globalNewCapturing();
private:
    void postProcessing( std::map<constants::metrics::Metrics,unsigned long> & old,
                                std::map<constants::metrics::Metrics,unsigned long> & actual);
    void globalPostProcessing(std::map<constants::metrics::Metrics,unsigned long> & actual);
    unsigned long  calculateCPUPercent(unsigned long procUsage, unsigned long cpuUsage);
    unsigned long  calculateTotalCPUPercent(unsigned long procUsage, unsigned long cpuUsage);
};

#endif //DATA_COLLECTOR_CAPTURE_H

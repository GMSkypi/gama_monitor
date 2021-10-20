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

class Capture {
private:
    std::vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics;
    std::map<constants::Paths,std::string> globalPaths;
    std::map<constants::metrics::Metrics,unsigned long> lastGlobalMetrics;
    std::map<constants::metrics::Metrics,unsigned long> actualGlobalMetrics;
    std::shared_ptr<FileReader> fileReader;
public:
    Capture(std::vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics,
            std::map<constants::Paths,std::string> globalPaths,
            std::shared_ptr<FileReader> fileReader);
    void newCapture(Container & container,std::vector<MetricsParserFactory::metricParserVP> unCapturedMetrics);
    void initNewCapturing();
private:
    void postProcessing( std::map<constants::metrics::Metrics,unsigned long> & old,
                                std::map<constants::metrics::Metrics,unsigned long> & actual);
    unsigned calculateCPUinPer();

};
// TODO accept paths

#endif //DATA_COLLECTOR_CAPTURE_H

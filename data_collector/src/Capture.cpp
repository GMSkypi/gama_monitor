//
// Created by gama on 06.10.21.
//

#include "Capture.h"

#include <utility>
#include <sstream>
#include <iostream>

void Capture::newCapture(Container & container, std::vector<MetricsParserFactory::metricParserVP> unCapturedMetrics) {
    std::map<constants::metrics::Metrics,unsigned long> actualMetric;
    for(const auto& parser : unCapturedMetrics){
       auto metricPaths = container.getMetricsPath();
        if(metricPaths.contains(parser.path)){
            parser.parser->parse(fileReader->readFile(metricPaths[parser.path]).str(),
                                 actualMetric);
        }
    }
    std::cout << container.getImage() + "  ->";
    postProcessing(container.getLastMetrics(),actualMetric);
    container.setLastMetrics(actualMetric);
    lastGlobalMetrics = move(actualGlobalMetrics);
}

Capture::Capture(std::vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics,
                 std::map<constants::Paths,std::string> globalPaths,
                 std::shared_ptr<FileReader> fileReader) {
    this->globalPaths = std::move(globalPaths);
    this->globalUnCapturedMetrics = std::move(globalUnCapturedMetrics);
    this->fileReader = std::move(fileReader);
}

void Capture::initNewCapturing() {
    for(const auto& parser : globalUnCapturedMetrics){
        if(globalPaths.contains(parser.path))
            parser.parser->parse(
                    fileReader->readFile(globalPaths[parser.path]).str(),
                    actualGlobalMetrics);
    }
}

unsigned Capture::calculateCPUinPer() {
    return 0;
}

void Capture::postProcessing( std::map<constants::metrics::Metrics,unsigned long> & old,
                              std::map<constants::metrics::Metrics,unsigned long> & actual) {
    if(old.size() == 0 || lastGlobalMetrics.size() == 0){
        return;
    }
    unsigned val = actual[constants::metrics::Metrics::CPU_PROC_TOTAL] - old[constants::metrics::Metrics::CPU_PROC_TOTAL];
    unsigned val2 = actualGlobalMetrics[constants::metrics::Metrics::CPU_TOTAL_ACUM] - lastGlobalMetrics[constants::metrics::Metrics::CPU_TOTAL_ACUM];
    if(val == 0 or val2 == 0){ // TODO val2 is different every time ?
        std::cout << "neno:" << val << std::endl;
    }
    else{
        std::cout << ((val * 1.0 / val2) * 100) << std::endl;
    }
}

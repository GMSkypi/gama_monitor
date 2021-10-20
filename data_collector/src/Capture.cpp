//
// Created by gama on 06.10.21.
//

#include "Capture.h"

#include <utility>
#include <sstream>

void Capture::newCapture(Container & container, std::vector<MetricsParserFactory::metricParserVP> unCapturedMetrics) {
    std::map<constants::metrics::Metrics,unsigned> actualMetric;
    for(const auto& parser : unCapturedMetrics){
       auto metricPaths = container.getMetricsPath();
        if(metricPaths.contains(parser.path)){
            parser.parser->parse(fileReader->readFile(metricPaths[parser.path]).str(),
                                 actualMetric);
        }
    }
    container.setLastMetrics(actualMetric);
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
                    lastGlobalMetrics);
    }
}

void Capture::postProcessing(std::map<constants::metrics::Metrics,unsigned> metric) {

}

unsigned Capture::calculateCPUinPer() {
    return 0;
}

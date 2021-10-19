//
// Created by gama on 06.10.21.
//

#include "Capture.h"

#include <utility>

void Capture::newCapture(Container & container, std::vector<MetricsParserFactory::metricParserVP> unCapturedMetrics) {
    for(const auto& parser : unCapturedMetrics){
        const auto & metricPaths = container.getMetricsPath();
        if(metricPaths.contains(parser.path)){
            //parser.parser->parse(fileReader->readFile(metricPaths.find(parser.path)),); // TODO;
        }
    }
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
            continue;
            //parser.parser->parse(this->fileReader->readFile(globalPaths[parser.path]),lastGlobalMetrics);
    }
}

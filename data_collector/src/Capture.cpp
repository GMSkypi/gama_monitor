//
// Created by gama on 06.10.21.
//

#include "Capture.h"
#include <sstream>
#include <iostream>
#include <unistd.h>

void Capture::newCapture(Container & container, std::vector<MetricsParserFactory::metricParserVP> unCapturedMetrics) {
    std::map<constants::metrics::Metrics,unsigned long> actualMetric;
    for(const auto& parser : unCapturedMetrics){
       auto metricPaths = container.getMetricsPath();
       try{
           if(metricPaths.contains(parser.path)){
               parser.parser->parse(fileReader->readFile(metricPaths[parser.path]).str(),
                                    actualMetric);
           }
       }
       catch (std::invalid_argument & exc){
           break;
       }
    }
    std::cout << container.getImage() + "  ->";
    postProcessing(container.getLastMetrics(),actualMetric);
    if(actualMetric.contains(Metrics::CPU_USER))
        std::cout << ((double) actualMetric[Metrics::CPU_USER]) / 1000 << std::endl;
    container.setLastMetrics(actualMetric);
}

Capture::Capture(std::vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics,
                 std::map<constants::Paths,std::string> globalPaths,
                 std::shared_ptr<FileReader> fileReader) {
    this->globalPaths = std::move(globalPaths);
    this->globalUnCapturedMetrics = std::move(globalUnCapturedMetrics);
    this->fileReader = std::move(fileReader);
}

void Capture::globalNewCapturing() {
    std::map<constants::metrics::Metrics,unsigned long> actualMetric;
    for(const auto& parser : globalUnCapturedMetrics){
        if(globalPaths.contains(parser.path))
            parser.parser->parse(
                    fileReader->readFile(globalPaths[parser.path]).str(),
                    actualMetric);
    }
    globalPostProcessing(actualMetric);
    lastGlobalMetrics = actualMetric;
}

void Capture::postProcessing( std::map<constants::metrics::Metrics,unsigned long> & old,
                              std::map<constants::metrics::Metrics,unsigned long> & actual) {
    if(!old.empty() && lastGlobalMetrics.contains(Metrics::CPU_TOTAL)){
        if(actual.contains(Metrics::CPU_USER_ACUM)) {
            unsigned long cpuUser = actual[Metrics::CPU_USER_ACUM]
                                    - old[Metrics::CPU_USER_ACUM];
            actual[Metrics::CPU_USER_TIME] = cpuUser;
            actual[Metrics::CPU_USER] = calculateCPUPercent(cpuUser,
                                                            lastGlobalMetrics[Metrics::CPU_TOTAL]);
        }
        if(actual.contains(Metrics::CPU_KERNEL_ACUM)) {
            unsigned long cpuKer = actual[Metrics::CPU_KERNEL_ACUM]
                                    - old[Metrics::CPU_KERNEL_ACUM];
            actual[Metrics::CPU_KERNEL_TIME] = cpuKer;
            actual[Metrics::CPU_KERNEL] = calculateCPUPercent(cpuKer,
                                                            lastGlobalMetrics[Metrics::CPU_TOTAL]);
        }
        if(actual.contains(Metrics::CPU_PROC_TOTAL)) {
            unsigned long cpuTotal = actual[Metrics::CPU_PROC_TOTAL]
                                   - old[Metrics::CPU_PROC_TOTAL];
            actual[Metrics::CPU_PROC] = calculateTotalCPUPercent(cpuTotal,
                                                              lastGlobalMetrics[Metrics::CPU_TOTAL]);
        }
    }
}

void Capture::globalPostProcessing(std::map<constants::metrics::Metrics, unsigned long> &actual) {
    if(!lastGlobalMetrics.empty()){
        actual[constants::metrics::Metrics::CPU_TOTAL] = (actual[constants::metrics::Metrics::CPU_TOTAL_ACUM]
        - lastGlobalMetrics[constants::metrics::Metrics::CPU_TOTAL_ACUM]);
    }
}

unsigned long Capture::calculateTotalCPUPercent(unsigned long procUsage, unsigned long cpuUsage) {
    if(procUsage == 0L || cpuUsage == 0L)
        return 0;
    return (unsigned long)(((((double) procUsage * 4 ) / 1000 ) / ((((double) cpuUsage) / (double) sysconf(_SC_CLK_TCK))*1000 * 1000)) * 100 * 1000);
}
unsigned long Capture::calculateCPUPercent(unsigned long procUsage, unsigned long cpuUsage){
    if(procUsage == 0L || cpuUsage == 0L)
        return 0;
    return (unsigned long)(((double) procUsage * 4) / ((double) cpuUsage) * 1000 * 100);
}

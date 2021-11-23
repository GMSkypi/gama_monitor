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
    if(actualMetric.contains(Metrics::CPU_PROC)) {
        std::cout << ((double) actualMetric[Metrics::CPU_PROC]) / 1000;
        std::cout << " , ";
        std::cout << (((double) actualMetric[Metrics::CPU_USER]) / 1000 + ((double) actualMetric[Metrics::CPU_KERNEL]) / 1000) << std::endl;
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
            actual[Metrics::CPU_USER_TIME] = (unsigned long)((((double)cpuUser) / sysconf(_SC_CLK_TCK)) * 1000);
            actual[Metrics::CPU_USER] = calculateCPUPercent(cpuUser,
                                                            lastGlobalMetrics[Metrics::CPU_TOTAL]);
        }
        if(actual.contains(Metrics::CPU_KERNEL_ACUM)) {
            unsigned long cpuKer = actual[Metrics::CPU_KERNEL_ACUM]
                                    - old[Metrics::CPU_KERNEL_ACUM];
            actual[Metrics::CPU_KERNEL_TIME] = (unsigned long)((((double)cpuKer) / sysconf(_SC_CLK_TCK)) * 1000);
            actual[Metrics::CPU_KERNEL] = calculateCPUPercent(cpuKer,
                                                            lastGlobalMetrics[Metrics::CPU_TOTAL]);
        }
        if(actual.contains(Metrics::CPU_PROC_TOTAL)) {
            unsigned long cpuTotal = actual[Metrics::CPU_PROC_TOTAL]
                                   - old[Metrics::CPU_PROC_TOTAL];
            actual[Metrics::CPU_PROC_TIME] = (unsigned long)(cpuTotal / 1000000);
            actual[Metrics::CPU_PROC] = calculateTotalCPUPercent(cpuTotal,
                                                              lastGlobalMetrics[Metrics::CPU_TOTAL]);
        }
        if(actual.contains(Metrics::IO_READ_ACC) && actual.contains((Metrics::IO_WRITE_ACC))){
            actual[Metrics::IO_READ] = actual[Metrics::IO_READ_ACC]
                                       - old[Metrics::IO_READ_ACC];
            actual[Metrics::IO_WRITE] = actual[Metrics::IO_WRITE_ACC]
                                       - old[Metrics::IO_WRITE_ACC];

        }
        if(actual.contains(Metrics::NET_RECEIVE_ACC)){
            actual[Metrics::NET_RECEIVE] = actual[Metrics::NET_RECEIVE_ACC]
                                       - old[Metrics::NET_RECEIVE_ACC];
            actual[Metrics::NET_RECEIVE_ERROR] = actual[Metrics::NET_RECEIVE_ERROR_ACC]
                                        - old[Metrics::NET_RECEIVE_ERROR_ACC];
            actual[Metrics::NET_TRANSMIT] = actual[Metrics::NET_TRANSMIT_ACC]
                                                 - old[Metrics::NET_TRANSMIT_ACC];
            actual[Metrics::NET_TRANSMIT_ERROR] = actual[Metrics::NET_TRANSMIT_ERROR_ACC]
                                            - old[Metrics::NET_TRANSMIT_ERROR_ACC];
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

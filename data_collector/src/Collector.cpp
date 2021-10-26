//
// Created by gama on 14.10.21.
//

#include <unistd.h>
#include <memory>
#include <utility>
#include "Collector.h"
#include "services/file_reader/LinuxFReader.h"
#include "services/path_generator/LinuxPathGenerator.h"
#include "services/MetricsParserFactory.h"
#include "obj/Container.h"
#include "services/explorer/ContainerExplorer.h"
#include "services/exec/ShellExec.h"
#include "../constants/LinuxBashCommands.h"
#include "parsers/DockerAPIParser.h"
#include "parsers/DockerBashParser.h"
#include "Capture.h"
#include "services/exec/CurlExec.h"
#include <thread>

Collector::Collector(const shared_ptr<Config>& conf) {
    oSystem = detectOS();
    switch(oSystem){
        case constants::LINUX:
            pathGenerator = shared_ptr<PathGenerator>(new LinuxPathGenerator());
            fileReader = shared_ptr<FileReader>(new LinuxFReader());
            break;
        default:
            throw runtime_error("Support for this system is not implemented yet");
    }
    this->conf = conf;
}

[[noreturn]] void Collector::startCapturing() {
    ContainerExplorer containerExplorer = loadExplorer();
    vector<Container> containers = containerExplorer.explore();
    // TODO get node info
    const map<constants::Paths,std::string> globalMetricsPaths = containerExplorer.globalPathInit();
    MetricsParserFactory metricsFactory;
    metricsFactory.addAllMetrics();
    const vector<MetricsParserFactory::metricParserVP> unCapturedMetrics = metricsFactory.getMetricSources();
    metricsFactory.addAllGlobalMetrics();
    const vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics = metricsFactory.getMetricSources();

    auto captureService = std::make_shared<Capture>(globalUnCapturedMetrics,
                                                          globalMetricsPaths,
                                                          fileReader);

    std::chrono::steady_clock::time_point exploreNewTimePoint =
            std::chrono::steady_clock::now() + std::chrono::milliseconds(conf->exploreDelay);
    std::chrono::steady_clock::time_point metricCaptureTimePoint = std::chrono::steady_clock::now();
    while(true){
    //for(int i = 0; i < 3; i++){
        std::chrono::steady_clock::time_point startTimePoint = std::chrono::steady_clock::now();
        if(std::chrono::duration_cast<std::chrono::milliseconds>(exploreNewTimePoint - startTimePoint).count() - 50 <=0){
            containerExplorer.exploreNew(containers);
            exploreNewTimePoint = std::chrono::steady_clock::now() + std::chrono::milliseconds(conf->exploreDelay);
        }


        if(std::chrono::duration_cast<std::chrono::milliseconds>(metricCaptureTimePoint - startTimePoint).count() -50  <= 0){
            captureService->globalNewCapturing();
            for(Container & container : containers)
                captureService->newCapture(container, unCapturedMetrics );
            metricCaptureTimePoint = std::chrono::steady_clock::now() + std::chrono::milliseconds(conf->metricDelay);
        }
        std::cout << "---------------------" << std::endl;

        std::chrono::steady_clock::time_point endTimePoint = std::chrono::steady_clock::now();

        if(exploreNewTimePoint > metricCaptureTimePoint){
            auto sleepFor = std::chrono::duration_cast<std::chrono::milliseconds>(metricCaptureTimePoint - endTimePoint);
            std::this_thread::sleep_for(sleepFor);
            continue;
        }
        auto sleepFor = std::chrono::duration_cast<std::chrono::milliseconds>(exploreNewTimePoint - endTimePoint);
        std::this_thread::sleep_for(sleepFor);

    };
}

constants::OS Collector::detectOS() {
    #if defined(WIN32) || defined(_WIN32) || defined(__WIN32__) || defined(__NT__)
        // Windows (32-bit and 64-bit)
        return constants::WINDOWS;
    #elif __APPLE__
        // apple
        return constants::APPLE;
    #elif __linux__
        // linux
        return constants::LINUX;
    #elif __unix__
        // Unix
        return constants::UNIX;
    #elif defined(_POSIX_VERSION)
        // POSIX
        return constants::POSIX;
    #else
        // unknown
        return constants::UNKNOWN;
    #endif
}

ContainerExplorer Collector::loadExplorer() {
    switch(conf->explorerParserOption){
        case 1:
            return ContainerExplorer(shared_ptr<Executor>(new ShellExec()),
                                      shared_ptr<parser::DockerParser>(new parser::DockerBashParser),
                                      pathGenerator,
                                      conf->blackList);
        case 2:
            return ContainerExplorer(shared_ptr<Executor>(new CurlExec),
                                     shared_ptr<parser::DockerParser>(new parser::DockerAPIParser),
                                     pathGenerator,
                                     conf->blackList);
        default:
            return ContainerExplorer(shared_ptr<Executor>(new CurlExec),
                                     shared_ptr<parser::DockerParser>(new parser::DockerAPIParser),
                                     pathGenerator,
                                     conf->blackList);
    }
}

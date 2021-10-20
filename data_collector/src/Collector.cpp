//
// Created by gama on 14.10.21.
//

#include <unistd.h>
#include <utility>
#include "Collector.h"
#include "services/file_reader/LinuxFReader.h"
#include "services/path_generator/LinuxPathGenerator.h"
#include "services/MetricsParserFactory.h"
#include "obj/Container.h"
#include "services/explorer/ContainerExplorer.h"
#include "services/exec/ShellExec.h"
#include "../constants/LinuxBashCommands.h"
#include "services/exec/CurlExec.h"
#include "parsers/DockerAPIParser.h"
#include "parsers/DockerBashParser.h"
#include "Capture.h"
#include <thread>

Collector::Collector() {
    oSystem = detectOS();
    switch(oSystem){
        case constants::LINUX:
            pathGenerator = shared_ptr<PathGenerator>(new LinuxPathGenerator());
            fileReader = shared_ptr<FileReader>(new LinuxFReader());
            executor = shared_ptr<Executor>(new ShellExec());
            break;
        default:
            throw runtime_error("Support for this system is not implemented yet");
    }
}

void Collector::startCapturing() {
    // TODO parser options
    ContainerExplorer containerExplorer = ContainerExplorer(executor,
                                                            shared_ptr<parser::DockerParser>(new parser::DockerBashParser),
                                                            pathGenerator);
    vector<Container> containers = containerExplorer.explore();
    const map<constants::Paths,std::string> globalMetricsPaths = containerExplorer.globalPathInit();
    MetricsParserFactory metricsFactory;
    metricsFactory.addAllMetrics();
    const vector<MetricsParserFactory::metricParserVP> unCapturedMetrics = metricsFactory.getMetricSources();
    metricsFactory.addAllGlobalMetrics();
    const vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics = metricsFactory.getMetricSources();

    auto captureService = shared_ptr<Capture>(new Capture(globalUnCapturedMetrics,
                                                          globalMetricsPaths,
                                                          fileReader));
    // add timer

    while(true){
        captureService->initNewCapturing(); // global metric does not have generated path
        // capture time
        containerExplorer.exploreNew(containers);

        for(Container & container : containers)
            captureService->newCapture(container, unCapturedMetrics );
        //sleep until delay
        std::this_thread::sleep_for(5000ms);
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

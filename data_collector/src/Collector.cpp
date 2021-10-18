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
    ContainerExplorer containerExplorer = ContainerExplorer(executor,shared_ptr<parser::DockerParser>(new parser::DockerBashParser));
    vector<Container> containers = containerExplorer.explore();
    MetricsParserFactory metricsFactory;
    vector<MetricsParserFactory::metricParserVP> unCapturedMetrics = metricsFactory.getMetricSources();
    // add timer
/*
    while(true){
        // capture time
        //containerExplorer.exploreNew(containers);
        for(Container container : containers)
            Capture.newCapture(&container, unCapturedMetrics );
        //sleep until delay
        cout << "capturing";
        break;
    }
    */

}

constants::OS Collector::detectOS() {
    #if defined(WIN32) || defined(_WIN32) || defined(__WIN32__) || defined(__NT__)
        // Windows (32-bit and 64-bit)
        return WINDOWS;
    #elif __APPLE__
        // apple
        return APPLE;
    #elif __linux__
        // linux
        return constants::LINUX;
    #elif __unix__
        // Unix
        return UNIX;
    #elif defined(_POSIX_VERSION)
        // POSIX
        return POSIX
    #else
        // unknown
        return UNKNOWN
    #endif
}

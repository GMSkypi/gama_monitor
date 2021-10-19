//
// Created by gama on 15.10.21.
//

#include "ContainerExplorer.h"
#include "../../parsers/StringParser.h"
#include <regex>

ContainerExplorer::ContainerExplorer(std::shared_ptr<Executor> executor,
                                     std::shared_ptr<parser::DockerParser> parser,
                                     std::shared_ptr<PathGenerator> pathGenerator) {
    this->executor = executor;
    this->parser = parser;
    this->pathGenerator = pathGenerator;
}
// TODO rename to explore and init
vector<Container> ContainerExplorer::explore() const {
    string data = executor->getContainers();
    vector<Container> exploredContainers = parser->parseContainerData(data);
    std::for_each(exploredContainers.begin(), exploredContainers.end(),
                  [this](Container & container){
                      unsigned pid = parser->parseContainerPid(executor->getPid(container.getId()));
                      container.setPid(pid);
                      containerPathInit(container);
                  });
    return exploredContainers;
}

void ContainerExplorer::exploreNew(vector<Container> &explored) const {
    // TODO
}
// TODO move to new class ?
void ContainerExplorer::containerPathInit(Container &container) const {
    const std::string & id = container.getId();
    std::map<constants::Paths,std::string> metricsPaths;
    metricsPaths[constants::Paths::CPU_USAGE] = pathGenerator->getCPUUsagePath(id);
    metricsPaths[constants::Paths::CPU_THROTTLE] = pathGenerator->getCPUThrottlePath(id);
    metricsPaths[constants::Paths::CPU_PROC_TOTAL] = pathGenerator->getCPUProcTotalPath(id);
    metricsPaths[constants::Paths::MEM] = pathGenerator->getMemoryPath(id);
    metricsPaths[constants::Paths::MEM_TOTAL] = pathGenerator->getTotalMemPath(id);
    metricsPaths[constants::Paths::MEM_TOTAL_SWAP] = pathGenerator->getTotalSwapMemPath(id);
    metricsPaths[constants::Paths::MEM_LIMITS] = pathGenerator->getMemLimitsPath(id);
    metricsPaths[constants::Paths::MEM_LIMIT_SWAP] = pathGenerator->getMemSwapLimitsPath(id);
    metricsPaths[constants::Paths::MEM_COUNT_LIMHIT] = pathGenerator->getMemHitCountPath(id);
    metricsPaths[constants::Paths::MEM_SWAP_LIMHIT] = pathGenerator->getMemSwapHitCountPath(id);
    metricsPaths[constants::Paths::IO] = pathGenerator->getIOPath(id);
    metricsPaths[constants::Paths::NET] = pathGenerator->getNetworkPath(container.getPid());
}

std::map<constants::Paths,std::string> ContainerExplorer::globalPathInit() const {
    std::map<constants::Paths,std::string> globalPaths;
    globalPaths[constants::Paths::CPU_TOTAL] = pathGenerator->getCPUTotalPath();
    return globalPaths;
}

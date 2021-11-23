//
// Created by gama on 15.10.21.
//

#include "ContainerExplorer.h"
#include "../../parsers/StringParser.h"
#include <regex>

ContainerExplorer::ContainerExplorer(std::shared_ptr<DockerExecutor> executor,
                                     std::shared_ptr<parser::DockerParser> parser,
                                     std::shared_ptr<PathGenerator> pathGenerator,
                                     std::vector<std::string> blackList) {
    this->executor = executor;
    this->parser = parser;
    this->pathGenerator = pathGenerator;
    this->blackList = blackList;
}
vector<Container> ContainerExplorer::explore(QDBController & dBController) const {
    string data = executor->getContainers();
    vector<Container> exploredContainers = parser->parseContainerData(data);
    excludeBlackList(exploredContainers);
    std::for_each(exploredContainers.begin(), exploredContainers.end(),
                  [this, &dBController](Container & container){
                      initContainer(container);
                      dBController.initContainer(container);
                  });
    return exploredContainers;
}

void ContainerExplorer::exploreNew(vector<Container> &existing, QDBController & dBController) const {
    string data = executor->getContainers();
    vector<Container> exploredContainers = parser->parseContainerData(data);
    excludeBlackList(exploredContainers);
    for( Container & expContainer : exploredContainers) {
        bool exist = std::find_if(existing.begin(),
                                  existing.end(),
                                  [this, &expContainer](const Container &exist) {
                                      return expContainer.getId() == exist.getId();
                                  }) != existing.end();
        // Container is new
        if (!exist) {
            initContainer(expContainer);
            dBController.initContainer((expContainer));
            existing.push_back(expContainer);
        }
    }
    // Some container is not running
    if (existing.size() > exploredContainers.size()) {
        std::erase_if(existing,
                      [&exploredContainers] (Container & exCont) {
            return (std::find_if(exploredContainers.begin(),
                                 exploredContainers.end(),
                                 [&exCont](const Container &explored) {
                                            return exCont.getId() == explored.getId();
                                            }) == exploredContainers.end());} );
    }
}
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
    container.setMetricsPath(metricsPaths);
}

std::map<constants::Paths,std::string> ContainerExplorer::globalPathInit() const {
    std::map<constants::Paths,std::string> globalPaths;
    globalPaths[constants::Paths::CPU_TOTAL] = pathGenerator->getCPUTotalPath();
    return globalPaths;
}

void ContainerExplorer::initContainer(Container &container) const {
    unsigned pid = parser->parseContainerPid(executor->getPid(container.getId()));
    container.setPid(pid);
    containerPathInit(container);
    // TODO init in database and get ID
}

void ContainerExplorer::excludeBlackList(std::vector<Container> & containers) const{
    for( const std::string & name : blackList) {
        auto exist = std::find_if(containers.begin(),
                                  containers.end(),
                                  [this, &name](const Container &container) {
                                      return container.getImage() == name;
                                  });
        if (exist != containers.end()) {
            containers.erase(exist);
        }
    }
}


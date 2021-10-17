//
// Created by gama on 15.10.21.
//

#include "ContainerExplorer.h"
#include "../../parsers/StringParser.h"
#include <regex>

ContainerExplorer::ContainerExplorer(std::shared_ptr<Executor> executor,std::shared_ptr<parser::DockerParser> parser) {
    this->executor = executor;
    this->parser = parser;
}

vector<Container> ContainerExplorer::explore() const {
    string data = executor->getContainers();
    vector<Container> exploredContainers = parser->parseContainerData(data);
    std::for_each(exploredContainers.begin(), exploredContainers.end(),
                  [this](Container container){
                      unsigned pid = parser->parseContainerPid(executor->getPid(container.getId()));
                      container.setPid(pid);
                  });
    return exploredContainers;
}

void ContainerExplorer::exploreNew(vector<Container> &explored) const {
    // TODO
}

//
// Created by gama on 15.10.21.
//

#include "ContainerExplorer.h"
#include "../../parsers/Parser.h"
#include <regex>

ContainerExplorer::ContainerExplorer(std::shared_ptr<Executor> executor) {
    this->executor = executor;
}

vector<Container> ContainerExplorer::explore() const {
    string data = executor->getContainers();
    vector<Container> exploredContainers = parser::parseContainerData(data);
    std::for_each(exploredContainers.begin(), exploredContainers.end(),
                  [this](Container container){
                      unsigned pid = stoul(executor->getPid(container.getId()), nullptr,0);
                      container.setPid(pid);
                  });
    return exploredContainers;
}

void ContainerExplorer::exploreNew(vector<Container> &explored) const {
    // TODO
}

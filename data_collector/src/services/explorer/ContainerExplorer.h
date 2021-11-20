//
// Created by gama on 14.10.21.
//

#ifndef DATA_COLLECTOR_CONTAINEREXPLORER_H
#define DATA_COLLECTOR_CONTAINEREXPLORER_H

#include <memory>
#include "../../obj/Container.h"
#include "vector"
#include "../exec/docker_exec/DockerExecutor.h"
#include "../../parsers/DockerParser.h"
#include "../path_generator/PathGenerator.h"

class ContainerExplorer{
private:
    std::shared_ptr<DockerExecutor> executor;
    std::shared_ptr<parser::DockerParser> parser;
    std::shared_ptr<PathGenerator> pathGenerator;
    std::vector<std::string> blackList;
public:
    explicit ContainerExplorer(std::shared_ptr<DockerExecutor> executor,
                               std::shared_ptr<parser::DockerParser> parser,
                               std::shared_ptr<PathGenerator> pathGenerator,
                               std::vector<std::string> blackList);
    [[nodiscard]] vector<Container> explore() const;
    void exploreNew(vector<Container> & existing) const;
    std::map<constants::Paths,std::string> globalPathInit() const;
private:
    void containerPathInit(Container & container) const;
    void initContainer(Container & container) const;
    void excludeBlackList(std::vector<Container> & containers) const;

};
#endif //DATA_COLLECTOR_CONTAINEREXPLORER_H

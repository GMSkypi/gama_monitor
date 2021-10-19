//
// Created by gama on 14.10.21.
//

#ifndef DATA_COLLECTOR_CONTAINEREXPLORER_H
#define DATA_COLLECTOR_CONTAINEREXPLORER_H

#include <memory>
#include "../../obj/Container.h"
#include "vector"
#include "../exec/Executor.h"
#include "../../parsers/DockerParser.h"
#include "../path_generator/PathGenerator.h"

class ContainerExplorer{
private:
    std::shared_ptr<Executor> executor;
    std::shared_ptr<parser::DockerParser> parser;
    std::shared_ptr<PathGenerator> pathGenerator;
public:
    explicit ContainerExplorer(std::shared_ptr<Executor> executor,
                               std::shared_ptr<parser::DockerParser> parser,
                               std::shared_ptr<PathGenerator> pathGenerator);
    [[nodiscard]] vector<Container> explore() const;
    void exploreNew(vector<Container> & explored) const;
    std::map<constants::Paths,std::string> globalPathInit() const;
private:
    void containerPathInit(Container & container) const;
};
#endif //DATA_COLLECTOR_CONTAINEREXPLORER_H

//
// Created by gama on 14.10.21.
//

#ifndef DATA_COLLECTOR_CONTAINEREXPLORER_H
#define DATA_COLLECTOR_CONTAINEREXPLORER_H

#include <memory>
#include "../../obj/Container.h"
#include "vector"
#include "../exec/Executor.h"

class ContainerExplorer{
private:
    std::shared_ptr<Executor> executor;
public:
    explicit ContainerExplorer(std::shared_ptr<Executor> executor);
    [[nodiscard]] vector<Container> explore() const;
    void exploreNew(vector<Container> & explored) const;
};
#endif //DATA_COLLECTOR_CONTAINEREXPLORER_H

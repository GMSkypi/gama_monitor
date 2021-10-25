//
// Created by gama on 14.10.21.
//

#ifndef DATA_COLLECTOR_COLLECTOR_H
#define DATA_COLLECTOR_COLLECTOR_H


#include <memory>
#include "services/path_generator/PathGenerator.h"
#include "services/file_reader/FileReader.h"
#include "../constants/Enums.h"
#include "services/exec/Executor.h"
#include "obj/Config.h"

class Collector {
private:
    std::shared_ptr<PathGenerator> pathGenerator;
    std::shared_ptr<FileReader> fileReader;
    constants::OS oSystem;
    std::shared_ptr<Executor> executor;
    std::shared_ptr<Config> conf;
public:
    Collector(const shared_ptr<Config>& conf);

    void startCapturing();
private:
    constants::OS detectOS();
};


#endif //DATA_COLLECTOR_COLLECTOR_H

//
// Created by gama on 25.10.21.
//

#ifndef DATA_COLLECTOR_INILOADER_H
#define DATA_COLLECTOR_INILOADER_H


#include <string>
#include "../../obj/Config.h"


namespace iniLoader{
    int loadConfig(const std::string & iniPath, std::shared_ptr<Config> & conf);
}


#endif //DATA_COLLECTOR_INILOADER_H

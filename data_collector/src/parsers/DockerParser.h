//
// Created by gama on 17.10.21.
//

#ifndef DATA_COLLECTOR_DOCKERPARSER_H
#define DATA_COLLECTOR_DOCKERPARSER_H

#include <string>
#include "../obj/Container.h"

namespace parser{
    class DockerParser{
    public:
        virtual std::vector <Container> parseContainerData(const std::string &data) = 0;
        virtual unsigned parseContainerPid(const std::string &data) = 0;
    };
}
#endif //DATA_COLLECTOR_DOCKERPARSER_H

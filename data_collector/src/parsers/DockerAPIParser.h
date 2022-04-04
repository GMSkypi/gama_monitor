//
// Created by gama on 17.10.21.
//

#ifndef DATA_COLLECTOR_DOCKERAPIPARSER_H
#define DATA_COLLECTOR_DOCKERAPIPARSER_H

#include <vector>
#include "DockerParser.h"


namespace parser{
    class DockerAPIParser : public DockerParser{

    public:
        std::vector<Container> parseContainerData(const std::string &data) override;
        unsigned int parseContainerPid(const std::string &data) override;
    };
}



#endif //DATA_COLLECTOR_DOCKERAPIPARSER_H

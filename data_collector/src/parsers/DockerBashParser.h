//
// Created by gama on 17.10.21.
//

#ifndef DATA_COLLECTOR_DOCKERBASHPARSER_H
#define DATA_COLLECTOR_DOCKERBASHPARSER_H

#include <vector>
#include "DockerParser.h"

using namespace std;
namespace parser{
    class DockerBashParser : public DockerParser {
        std::vector <Container> parseContainerData(const std::string &data) override;

    public:
        unsigned int parseContainerPid(const string &data) override;
    };
}



#endif //DATA_COLLECTOR_DOCKERBASHPARSER_H

//
// Created by gama on 17.10.21.
//

#include <regex>
#include "DockerBashParser.h"
#include "StringParser.h"


std::vector <Container> parser::DockerBashParser::parseContainerData(const std::string &data) {
    vector<string> lines = tokenize(data,regex("\\n"));
    vector<Container> exploredContainers;
    for(unsigned i = 1; i < lines.size(); i++){
        string line = lines[i];
        vector<string> values = tokenize(line,regex("\\s\\s"));
        if(values.size() != 6 and values.size() != 7  ) // size of docker ps
            throw out_of_range("Parsing Docker PS error");
        exploredContainers.emplace_back(values[0],values[values.size()],0,values[1]);
    }
    return exploredContainers;
}

unsigned int parser::DockerBashParser::parseContainerPid(const string &data) {
    return stoul(data, nullptr,0);
}

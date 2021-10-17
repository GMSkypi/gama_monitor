//
// Created by gama on 15.10.21.
//

#include "Parser.h"

vector<string> parser::tokenize(const string & data,const regex& regex) {
    sregex_token_iterator iter{ data.begin(),data.end(),regex, -1 };
    std::vector<std::string> tokenized{ iter, {} };

    tokenized.erase(std::remove_if(tokenized.begin(),
                           tokenized.end(),
                           [](std::string const& s) {
                               return s.size() == 0;
                           }),
            tokenized.end());

    return tokenized;
}

vector<Container> parser::parseContainerData(const string &data) {
    vector<string> lines = tokenize(data,regex("\\n"));
    vector<Container> exploredContainers;
    for(unsigned i = 1; i < lines.size(); i++){
        string line = lines[i];
        vector<string> values = tokenize(line,regex("\\s\\s"));
        if(values.size() != 7) // size of docker ps
            throw out_of_range("Parsing Docker PS error");
        exploredContainers.emplace_back(values[0],values[6],0,values[1]);
    }
    return exploredContainers;
}

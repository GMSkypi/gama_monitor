//
// Created by gama on 15.10.21.
//

#ifndef DATA_COLLECTOR_PARSER_H
#define DATA_COLLECTOR_PARSER_H
#include <string>
#include <regex>
#include "../obj/Container.h"

using namespace std;

namespace parser{

    vector<string> tokenize(
            const string & str,
            const regex& re);

    vector<Container> parseContainerData(const string  & data);
}


#endif //DATA_COLLECTOR_PARSER_H

//
// Created by gama on 15.10.21.
//

#ifndef DATA_COLLECTOR_STRINGPARSER_H
#define DATA_COLLECTOR_STRINGPARSER_H
#include <string>
#include <regex>
#include "../obj/Container.h"

using namespace std;

namespace parser{

    vector<string> tokenize(
            const string & str,
            const regex& re);
}


#endif //DATA_COLLECTOR_STRINGPARSER_H

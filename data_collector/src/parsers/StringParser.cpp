//
// Created by gama on 15.10.21.
//

#include "StringParser.h"

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


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
unsigned long parser::getUnsignedFromString(const std::string & number){
    if(number.length() >= 19){
        return 0;
    }
    return std::stoul(number, nullptr,0);
}
std::string parser::firstMatchRegex(const std::string & data, const regex& regex){
    return matchRegex(data,regex)[0];
}
std::smatch parser::matchRegex(const std::string & data, const regex& regex){
    std::smatch match;
    std::regex_search(data.begin(),data.end(),match,regex);
    return match;
}


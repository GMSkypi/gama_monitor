//
// Created by gama on 21.11.21.
//

#include <iostream>
#include "QDBAPIParser.h"
#include "../../external/rapidjson/document.h"

unsigned parser::QDBAPIParser::parseNumberOfColumn(const std::string& data) {
    try {
        rapidjson::Document jsonDoc;
        jsonDoc.Parse(data.c_str());
        assert(jsonDoc.IsObject()); // each attribute is an object
        rapidjson::Value &count = jsonDoc["count"];
        assert(count.IsUint()); // attributes is an array
        return count.GetUint();
    }
    catch(std::exception & e){
        std::cout << data << std::endl;
    }
}

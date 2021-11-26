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
        if(jsonDoc.HasMember("error")) {
            rapidjson::Value &error = jsonDoc["error"];
            std::cout << error.GetString() << std::endl;
            throw std::invalid_argument("response error");
        }
        rapidjson::Value &count = jsonDoc["count"];
        assert(count.IsUint()); // attributes is an array
        return count.GetUint();
    }
    catch(std::exception & e){
        std::cout << data << std::endl;
        return 0;
    }
}

bool parser::QDBAPIParser::checkForError(const std::string& data) {
    rapidjson::Document jsonDoc;
    jsonDoc.Parse(data.c_str());
    assert(jsonDoc.IsObject()); // each attribute is an object
    return (jsonDoc.HasMember("error"));
}

bool parser::QDBAPIParser::checkCreate(const std::string &data) {
    // "{\"query\":\"ALTER TABLE CPU ALTER COLUMN Container_id ADD INDEX;\",\"error\":\"already indexed [column=Container_id][errno=0]\",\"position\":12}"
    rapidjson::Document jsonDoc;
    jsonDoc.Parse(data.c_str());
    assert(jsonDoc.IsObject()); // each attribute is an object
    if(jsonDoc.HasMember("ddl")){
        rapidjson::Value &val = jsonDoc["ddl"];
        return strcmp(val.GetString(), "OK") == 0;
    }
    else if(jsonDoc.HasMember("error")){
        rapidjson::Value &error = jsonDoc["error"];
        return (std::string(error.GetString()).compare(0, 15, "already indexed")) == 0;
    }
    return false;
}

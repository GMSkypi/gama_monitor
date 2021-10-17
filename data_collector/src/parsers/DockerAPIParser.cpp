//
// Created by gama on 17.10.21.
//

#include "DockerAPIParser.h"
#include "../../external/rapidjson/document.h"
#include <iostream>

std::vector<Container> parser::DockerAPIParser::parseContainerData(const std::string &data) {
    std::vector<Container> exploredContainers;
    rapidjson::Document jsonDoc;
    jsonDoc.Parse(data.c_str());
    assert(jsonDoc.IsArray()); // attributes is an array
    for (rapidjson::Value::ConstValueIterator itr = jsonDoc.Begin(); itr != jsonDoc.End(); ++itr) {
        const rapidjson::Value& attribute = *itr;
        assert(attribute.IsObject()); // each attribute is an object
        exploredContainers.emplace_back(attribute["Id"].GetString(),
                                      "",
                                      0,
                                      attribute["Image"].GetString());
    }
    return exploredContainers;
}

unsigned int parser::DockerAPIParser::parseContainerPid(const std::string &data) {
    return 1;
}

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
        const rapidjson::Value& namesValue = attribute["Names"];

        std::vector<std::string> namesArray;
        for (rapidjson::SizeType i = 0; i < namesValue.Size(); i++)
            namesArray.emplace_back(namesValue[i].GetString());

        exploredContainers.emplace_back(attribute["Id"].GetString(),
                                        namesArray,
                                      0,
                                      attribute["Image"].GetString());
    }
    if(exploredContainers.size() > 5){
        std::cout << "dwa";
    }
    return exploredContainers;
}

unsigned int parser::DockerAPIParser::parseContainerPid(const std::string &data) {
    rapidjson::Document jsonDoc;
    jsonDoc.Parse(data.c_str());
    const rapidjson::Value& attribute = jsonDoc["Processes"];
    const rapidjson::Value& titles = jsonDoc["Titles"];

    for (rapidjson::SizeType i = 0; i < titles.Size() && i < attribute[0].Size(); i++){
        if( strcmp(titles[i].GetString(),"PID") == 0){
            return std::stoul(attribute[0][i].GetString(), nullptr,0);
        }

    }
    return 1;
}

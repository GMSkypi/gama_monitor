//
// Created by gama on 25.10.21.
//

#include "IniLoader.h"

#include <memory>
#include "../../../external/simpleIni/SimpleIni.h"
#include "../../obj/Config.h"
#include "../../parsers/StringParser.h"

int iniLoader::loadConfig(const std::string & iniPath,  std::shared_ptr<Config> & conf) {
    CSimpleIniA ini;
    ini.SetUnicode();

    SI_Error rc = ini.LoadFile(iniPath.c_str());
    if (rc < 0) { /* 1handle error */ };
    if(rc ==  SI_OK){

        const char* dbSocket;
        dbSocket = ini.GetValue("config_db", "socket");
        const char* socketPortChar;
        socketPortChar = ini.GetValue("config_db", "socket_port");
        int socketPort = parser::getUnsignedFromString(socketPortChar);
        const char* questdbURL;
        questdbURL = ini.GetValue("config_db", "questdb_url");

        const char* metricDelayString;
        metricDelayString = ini.GetValue("delays", "metric_delay");
        unsigned long metricDelay = parser::getUnsignedFromString(metricDelayString);

        const char* exploreDelayString;
        exploreDelayString = ini.GetValue("delays", "explore_delay");
        unsigned long exportDelay = parser::getUnsignedFromString(exploreDelayString);

        std::vector<std::string> blackList;
        CSimpleIniA::TNamesDepend keys;
        ini.GetAllKeys("black_list", keys);
        for(auto & key : keys){
            blackList.emplace_back(ini.GetValue("black_list", key.pItem));
        }

        const char* explorerParserOptionString;
        explorerParserOptionString = ini.GetValue("other", "explorer_parser_option");
        unsigned long explorerParserOption = parser::getUnsignedFromString(explorerParserOptionString);


        conf = std::make_shared<Config>(
                DBConfig(dbSocket,socketPort,questdbURL),
                metricDelay,
                exportDelay,
                blackList,
                explorerParserOption);

        return 0;
    }
    return 1;
}

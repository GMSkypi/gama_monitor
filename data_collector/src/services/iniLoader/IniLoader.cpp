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

        const char* database_IP;
        database_IP = ini.GetValue("config", "database_IP");
        const char* login;
        login = ini.GetValue("config", "login");
        const char* password;
        password = ini.GetValue("config", "password");

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
                DBConfig(database_IP,login,password),
                metricDelay,
                exportDelay,
                blackList,
                explorerParserOption);

        return 0;
    }
    return 1;
}

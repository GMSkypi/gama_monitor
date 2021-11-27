#include <utility>
#include <memory>
#include <vector>

//
// Created by gama on 24.10.21.
//

#ifndef DATA_COLLECTOR_CONFIG_H
#define DATA_COLLECTOR_CONFIG_H

class DBConfig {
public:
    std::string dbSocket;
    int socketPort;
    std::string questdbURL;
    std::string questdbHealthUrl;

    DBConfig(std::string dbSocket,
             int socketPort,
             std::string questdbURL,
             std::string questdbHealthUrl) :
            dbSocket(std::move(dbSocket)),
            socketPort(socketPort),
            questdbHealthUrl(std::move(questdbHealthUrl)),
            questdbURL(std::move(questdbURL)) {}

};

class Config {
public:
    DBConfig database;
    unsigned metricDelay;
    unsigned exploreDelay;
    std::vector<std::string> blackList;
    unsigned explorerParserOption;
    Config(DBConfig db,
           unsigned metricDelay,
           unsigned exploreDelay,
           std::vector<std::string> blackList,
           unsigned explorerParserOption) : database(std::move(db)),
                                            metricDelay(metricDelay),
                                            exploreDelay(exploreDelay),
                                            blackList(std::move(blackList)),
                                            explorerParserOption(explorerParserOption){}
};


#endif //DATA_COLLECTOR_CONFIG_H

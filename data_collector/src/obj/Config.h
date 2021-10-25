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
    std::string database_IP;
    std::string login;
    std::string password;

    DBConfig(std::string database_IP,
             std::string login,
             std::string password) :
            database_IP(std::move(database_IP)),
            login(std::move(login)),
            password(std::move(password)) {}

};

class Config {
public:
    DBConfig database;
    unsigned metricDelay;
    unsigned exploreDelay;
    std::vector<std::string> blackList;
    Config(DBConfig db,
           unsigned metricDelay,
           unsigned exploreDelay,
           std::vector<std::string> blackList) : database(std::move(db)),
                                                 metricDelay(metricDelay),
                                                 exploreDelay(exploreDelay),
                                                 blackList(std::move(blackList)) {}
};


#endif //DATA_COLLECTOR_CONFIG_H

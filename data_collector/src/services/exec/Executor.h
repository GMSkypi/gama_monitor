//
// Created by gama on 20.11.21.
//

#ifndef DATA_COLLECTOR_EXECUTOR_H
#define DATA_COLLECTOR_EXECUTOR_H
#include "string"

class Executor{
public:
    virtual std::string exec(const char* cmd) = 0;
    virtual void init() = 0;
    virtual void exit() = 0;
};
#endif //DATA_COLLECTOR_EXECUTOR_H


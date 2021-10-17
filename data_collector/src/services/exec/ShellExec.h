//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_SHELLEXEC_H
#define DATA_COLLECTOR_SHELLEXEC_H
#include <cstdio>
#include <iostream>
#include <memory>
#include <stdexcept>
#include <string>
#include <array>
#include "Executor.h"

using namespace std;
class ShellExec : public Executor {
public:
    string exec(const char* cmd) override ;

    string getPid(const string & containerID) override;

    string getContainers() override;
};


#endif //DATA_COLLECTOR_SHELLEXEC_H

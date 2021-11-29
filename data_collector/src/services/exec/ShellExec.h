//
// Created by gama on 20.11.21.
//

#ifndef DATA_COLLECTOR_SHELLEXEC_H
#define DATA_COLLECTOR_SHELLEXEC_H


#include "Executor.h"
#include <stdexcept>
#include <memory>

using namespace std;

class ShellExec : public Executor{
public:
    string exec(const char *cmd) override;

    void init() override;

    void exit() override;
};


#endif //DATA_COLLECTOR_SHELLEXEC_H

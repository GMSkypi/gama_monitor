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

using namespace std;
class ShellExec {
public:
    static string exec(const char* cmd);

};


#endif //DATA_COLLECTOR_SHELLEXEC_H

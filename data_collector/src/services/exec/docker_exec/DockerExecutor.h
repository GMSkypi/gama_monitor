//
// Created by gama on 15.10.21.
//

#ifndef DATA_COLLECTOR_DOCKEREXECUTOR_H
#define DATA_COLLECTOR_DOCKEREXECUTOR_H
#include "string"
using namespace std;

class DockerExecutor{
public:
    virtual string getPid(const string & containerID) = 0;
    virtual string getContainers() = 0;
};

#endif //DATA_COLLECTOR_DOCKEREXECUTOR_H

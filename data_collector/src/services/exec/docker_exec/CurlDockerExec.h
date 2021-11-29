//
// Created by gama on 17.10.21.
//

#ifndef DATA_COLLECTOR_CURLDOCKEREXEC_H
#define DATA_COLLECTOR_CURLDOCKEREXEC_H


#include "DockerExecutor.h"
#include "../../../../constants/DockerAPICommands.h"
#include "../CurlExec.h"

class CurlDockerExec : public DockerExecutor{
private:
    CurlExec executor = CurlExec(dockerAPI::dockerSocketPath);
public:
    CurlDockerExec();
    ~CurlDockerExec();
    string getPid(const string &containerID) override;

    string getContainers() override;
};


#endif //DATA_COLLECTOR_CURLDOCKEREXEC_H

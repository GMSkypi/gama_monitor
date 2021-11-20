//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_SHELLDOCKEREXEC_H
#define DATA_COLLECTOR_SHELLDOCKEREXEC_H
#include "DockerExecutor.h"
#include "../ShellExec.h"
#include "../../../../constants/LinuxBashCommands.h"

using namespace std;
class ShellDockerExec : public DockerExecutor {
private:
    ShellExec executor = ShellExec();
public:
    ShellDockerExec();
    ~ShellDockerExec();
    string getPid(const string & containerID) override;

    string getContainers() override;
};


#endif //DATA_COLLECTOR_SHELLDOCKEREXEC_H

//
// Created by gama on 06.10.21.
//

#include "ShellDockerExec.h"


string ShellDockerExec::getPid(const string & containerID) {
    return executor.exec((linuxBashCommands::dockerPIDCommandLinux + containerID).c_str());
}

string ShellDockerExec::getContainers() {
    return executor.exec(linuxBashCommands::dockerPSCommandLinux.c_str());
}

ShellDockerExec::ShellDockerExec() {
    executor.init();
}

ShellDockerExec::~ShellDockerExec() {
    executor.exit();
}

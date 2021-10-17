//
// Created by gama on 06.10.21.
//

#include "ShellExec.h"
#include "../../../constants/LinuxBashCommands.h"

string ShellExec::exec(const char *cmd){
    array<char, 128> buffer{};
    unique_ptr<FILE, decltype(&pclose)> pipe(popen(cmd, "r"), pclose);
    if (!pipe) {
        throw std::runtime_error("Failed to exec");
    }
    string output;
    while (fgets(buffer.data(), buffer.size(), pipe.get()) != nullptr) {
        output += buffer.data();
    }
    return output;
}

string ShellExec::getPid(const string & containerID) {
    return exec((linuxBashCommands::dockerPIDCommandLinux + containerID).c_str());
}

string ShellExec::getContainers() {
    return exec(linuxBashCommands::dockerPSCommandLinux.c_str());
}

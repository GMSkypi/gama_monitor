//
// Created by gama on 20.11.21.
//

#include "ShellExec.h"

string ShellExec::exec(const char *cmd) {
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

void ShellExec::init() {}

void ShellExec::exit() {}

//
// Created by gama on 17.10.21.
//

#include "CurlDockerExec.h"

string CurlDockerExec::getPid(const string &containerID) {
    return executor.exec((dockerAPI::containersSpecURL + containerID + "/top").c_str());
}

string CurlDockerExec::getContainers() {
    return executor.exec(dockerAPI::containersURL.c_str());;
}

CurlDockerExec::CurlDockerExec() {
    executor.init();
}

CurlDockerExec::~CurlDockerExec() {
    executor.exit();
}

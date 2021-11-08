//
// Created by gama on 17.10.21.
//

#include <cstring>
#include "CurlExec.h"
#include "../../../constants/DockerAPICommands.h"

string CurlExec::exec(const char *cmd) {
    Memory mem{};
    initMemory(&mem);
    auto curl = curl_easy_init();
    initCurl(&mem,curl);

    curl_easy_setopt(curl, CURLOPT_URL, cmd);
    CURLcode response = curl_easy_perform(curl);
    curl_easy_reset(curl);

    if (response == CURLE_OK){
        string result(mem.response);
        free(mem.response);
        curl_easy_cleanup(curl);
        return result;
    }
    free(mem.response);
    curl_easy_cleanup(curl);
    // TODO throw
    return std::string();
}

string CurlExec::getPid(const string &containerID) {
    return exec((dockerAPI::containersSpecURL + containerID + "/top").c_str());
}

string CurlExec::getContainers() {
    return exec(dockerAPI::containersURL.c_str());;
}


size_t CurlExec::writeFunction(void *data, size_t size, size_t nmemb, void *buffer) {
    size_t realSize = size * nmemb;
    auto *mem = (struct Memory *)buffer;

    mem->response = static_cast<char *>(realloc(mem->response, mem->size + realSize + 1));
    if(  mem->response == nullptr)
        return 0;  /* out of memory! */

    memcpy(&(mem->response[mem->size]), data, realSize);
    mem->size += realSize;
    mem->response[mem->size] = 0;

    return realSize;
}

void CurlExec::initCurl(Memory * mem , CURL *curl) {
    curl_easy_setopt(curl, CURLOPT_UNIX_SOCKET_PATH, "/var/run/docker.sock");
    curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, writeFunction);
    curl_easy_setopt(curl, CURLOPT_WRITEDATA, mem);
}

void CurlExec::initMemory(CurlExec::Memory * mem) {
    mem->response = (char *) malloc(1);
    mem->size = 0;
}

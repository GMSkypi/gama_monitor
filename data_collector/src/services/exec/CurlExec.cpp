//
// Created by gama on 20.11.21.
//

#include "CurlExec.h"

std::string CurlExec::exec(const char *cmd) {
    Memory mem{};
    initMemory(&mem);
    auto curl = curl_easy_init();
    initCurl(&mem,curl);

    curl_easy_setopt(curl, CURLOPT_URL, cmd);
    CURLcode response = curl_easy_perform(curl);
    curl_easy_reset(curl);

    if (response == CURLE_OK){
        std::string result(mem.response);
        free(mem.response);
        curl_easy_cleanup(curl);
        return result;
    }
    free(mem.response);
    curl_easy_cleanup(curl);
    // TODO throw
    return std::string();
}

void CurlExec::init() {

}

void CurlExec::exit() {

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
    if(!this->socketPath.empty())
        curl_easy_setopt(curl, CURLOPT_UNIX_SOCKET_PATH, socketPath.c_str());
    curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, writeFunction);
    curl_easy_setopt(curl, CURLOPT_WRITEDATA, mem);
}

void CurlExec::initMemory(CurlExec::Memory * mem) {
    mem->response = (char *) malloc(1);
    mem->size = 0;
}

CurlExec::CurlExec(const std::string & socketPath) {
    this->socketPath = socketPath;
}

CurlExec::CurlExec() {}

std::string CurlExec::exec(const char *cmd, const char *query) {
    char * queryEncoded = curl_easy_escape(nullptr,query,strlen(query));
    std::string newCmd = std::string(cmd) + "?query=" + std::string(queryEncoded);
    return exec(newCmd.c_str());
}

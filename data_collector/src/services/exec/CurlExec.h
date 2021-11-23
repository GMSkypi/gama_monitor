//
// Created by gama on 20.11.21.
//

#ifndef DATA_COLLECTOR_CURLEXEC_H
#define DATA_COLLECTOR_CURLEXEC_H


#include "../../../external/curl/curl.h"
#include "Executor.h"
#include <cstring>

class CurlExec : public Executor{
private:
    std::string socketPath;
public:
    CurlExec(const std::string & socketPath);
    CurlExec();
    std::string exec(const char *cmd) override;
    std::string exec(const char *cmd, const char *query);

    void init() override;

    void exit() override;

private:
    struct Memory {
        char *response;
        size_t size;
    };
    static size_t writeFunction(void *data, size_t size, size_t nmemb, void *buffer);
    void initCurl(Memory * mem, CURL *curl);
    void initMemory(Memory * mem);
};


#endif //DATA_COLLECTOR_CURLEXEC_H

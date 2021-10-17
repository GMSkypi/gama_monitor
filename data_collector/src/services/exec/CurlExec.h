//
// Created by gama on 17.10.21.
//

#ifndef DATA_COLLECTOR_CURLEXEC_H
#define DATA_COLLECTOR_CURLEXEC_H


#include "Executor.h"
#include "../../../external/curl/curl.h"

class CurlExec : public Executor{
public:

    string exec(const char *cmd) override;

    string getPid(const string &containerID) override;

    string getContainers() override;
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

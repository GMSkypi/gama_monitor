//
// Created by gama on 20.11.21.
//

#ifndef DATA_COLLECTOR_SOCKETEXEC_H
#define DATA_COLLECTOR_SOCKETEXEC_H


#include "Executor.h"
#include <sys/socket.h>
#include <arpa/inet.h>
#include <cstring>
#include <unistd.h>

using namespace std;
class SocketExec : public Executor {
private:
    string ip;
    bool tcpTrue;
    unsigned port;
    int sock = 0;
public:
    SocketExec(const string & ip, bool tcpTrue, unsigned port);
    string exec(const char *cmd) override;

    void init() override;

    void exit() override;
};


#endif //DATA_COLLECTOR_SOCKETEXEC_H

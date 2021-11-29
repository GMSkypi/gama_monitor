//
// Created by gama on 20.11.21.
//

#include "SocketExec.h"


string SocketExec::exec(const char *cmd) {
    send(sock , cmd , strlen(cmd) , 0 );
    return {};
}

void SocketExec::init() {
    int valread;
    struct sockaddr_in serv_addr;
    if ((sock = socket(AF_INET, SOCK_STREAM, 0)) < 0)
    {
        printf("\n Socket creation error \n");
        return;
    }

    serv_addr.sin_family = AF_INET;
    serv_addr.sin_port = htons(port);

    // Convert IPv4 and IPv6 addresses from text to binary form
    if(inet_pton(AF_INET, ip.c_str(), &serv_addr.sin_addr)<=0)
    {
        printf("\nInvalid address/ Address not supported \n");
        return;
    }

    if (connect(sock, (struct sockaddr *)&serv_addr, sizeof(serv_addr)) < 0)
    {
        printf("\nConnection Failed \n");
        return;
    }
}

void SocketExec::exit() {
    close(sock);
}

SocketExec::SocketExec(const string & ip, bool tcpTrue, unsigned port) {
    this->ip = ip;
    this->tcpTrue = tcpTrue;
    this->port = port;
}

//
// Created by gama on 20.11.21.
//

#include <netdb.h>
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

    struct addrinfo *result = nullptr;
    if (getaddrinfo(ip.c_str(), NULL, NULL, &result) != 0)
    {
        printf("unable to resolve\n");
        return;
    }
    char ipstr[INET_ADDRSTRLEN];

    struct in_addr  *addr;
    if (result->ai_family == AF_INET) {
        auto *ipv = (struct sockaddr_in *)result->ai_addr;
        addr = &(ipv->sin_addr);
    }
    else {
        auto *ipv6 = (struct sockaddr_in6 *)result->ai_addr;
        addr = (struct in_addr *) &(ipv6->sin6_addr);
    }
    inet_ntop(result->ai_family, addr, ipstr, sizeof ipstr);

    // Convert IPv4 and IPv6 addresses from text to binary form
    if(inet_pton(AF_INET, ipstr, &serv_addr.sin_addr)<=0)
    {
        printf("\nInvalid address/ Address not supported \n");
        printf("Address: %s\n", ipstr);
        return;
    }

    if (connect(sock, (struct sockaddr *)&serv_addr, sizeof(serv_addr)) < 0)
    {
        printf("\nConnection Failed \n");
        return;
    }
    freeaddrinfo(result);
}

void SocketExec::exit() {
    close(sock);
}

SocketExec::SocketExec(const string & ip, bool tcpTrue, unsigned port) {
    this->ip = ip;
    this->tcpTrue = tcpTrue;
    this->port = port;
}

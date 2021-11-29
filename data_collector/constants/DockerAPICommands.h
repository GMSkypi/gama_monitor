//
// Created by gama on 17.10.21.
//

#ifndef DATA_COLLECTOR_DOCKERAPICOMMANDS_H
#define DATA_COLLECTOR_DOCKERAPICOMMANDS_H

namespace dockerAPI{
    const string containersURL = "http://v1.25/containers/json?status=running";
    const string containersSpecURL = "http://v1.25/containers/";
    const string dockerSocketPath = "/var/run/docker.sock";
}

#endif //DATA_COLLECTOR_DOCKERAPICOMMANDS_H

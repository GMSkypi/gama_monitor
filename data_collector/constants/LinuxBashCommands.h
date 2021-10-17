//
// Created by gama on 14.10.21.
//

#ifndef DATA_COLLECTOR_LINUXBASHCOMMANDS_H
#define DATA_COLLECTOR_LINUXBASHCOMMANDS_H

namespace linuxBashCommands{
    const string dockerPSCommandLinux = "docker ps --no-trunc";
    const string dockerPIDCommandLinux = "docker inspect -f '{{ .State.Pid}}' ";
}

#endif //DATA_COLLECTOR_LINUXBASHCOMMANDS_H

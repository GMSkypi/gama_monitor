#include <iostream>
#include <sstream>
#include "services/exec/docker_exec/ShellDockerExec.h"
#include "services/file_reader/LinuxFReader.h"
#include "services/path_generator/LinuxPathGenerator.h"
#include "Collector.h"
#include "services/iniLoader/IniLoader.h"
#include "obj/Config.h"

using namespace std;
int main() {
    shared_ptr<Config> conf;
    iniLoader::loadConfig(linuxSourcePaths::iniPath,conf );
    Collector collector = Collector(conf);
    collector.startCapturing();
    return 0;
}

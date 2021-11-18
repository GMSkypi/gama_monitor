//
// Created by gama on 08.11.21.
//

#ifndef DATA_COLLECTOR_FILEEXPORTER_H
#define DATA_COLLECTOR_FILEEXPORTER_H


#include <string>
#include <fstream>
#include "../obj/Container.h"
#include <chrono>

class FileExporter {
private:
    std::string path;
    std::ofstream file;
    std::chrono::steady_clock::time_point startTimePoint;
public:
    explicit FileExporter(std::string path);
    ~FileExporter();
    void exportMetrics(Container * container);
};


#endif //DATA_COLLECTOR_FILEEXPORTER_H

//
// Created by gama on 08.11.21.
//

#include <iostream>
#include "FileExporter.h"
#include "../../constants/Enums.h"

FileExporter::FileExporter(std::string path){
    file.open (path);
    this->path = move(path);
    startTimePoint = std::chrono::steady_clock::now();
}
FileExporter::~FileExporter(){
    file.close();
}

void FileExporter::exportMetrics(Container *container) {
    auto & metrics = container->getLastMetrics();
    std::chrono::steady_clock::time_point nowTimePoint = std::chrono::steady_clock::now();
    file << std::chrono::duration_cast<std::chrono::seconds>(nowTimePoint - startTimePoint).count();
    file << " ";
    file << metrics[constants::metrics::Metrics::CPU_PROC];
    file << " ";
    file << metrics[constants::metrics::Metrics::CPU_USER];
    file << " ";
    file << metrics[constants::metrics::Metrics::CPU_KERNEL];
    file << " ";
    file << metrics[constants::metrics::Metrics::MEM_USED_SWAP];
    file << " ";
    file << metrics[constants::metrics::Metrics::IO_WRITE];
    file << "\n";
}

//
// Created by gama on 06.10.21.
//
#include <sstream>
#include <fstream>
#include "LinuxFReader.h"

std::stringstream LinuxFReader::readFile(const std::string & filePath) {
    std::ifstream file;
    file.open (filePath);
    if(file){
        std::stringstream buffer;
        buffer << file.rdbuf();
        file.close();
        return buffer;
    }
    else{
        throw std::invalid_argument("Invalid file name" + filePath);
    }
}
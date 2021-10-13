//
// Created by gama on 06.10.21.
//
#include <sstream>
#include <fstream>
#include "LinuxFReader.h"

stringstream LinuxFReader::readFile(string filePath) {
    ifstream file;
    file.open (filePath);
    if(file){
        stringstream buffer;
        buffer << file.rdbuf();
        file.close();
        return buffer;
    }
    else{
        throw invalid_argument("Invalid file name" + filePath);
    }
}
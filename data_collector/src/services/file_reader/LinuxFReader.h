//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_LINUXFREADER_H
#define DATA_COLLECTOR_LINUXFREADER_H
#include "FileReader.h"

class LinuxFReader: public FileReader{
public:
    stringstream readFile(string filePath) override;
};
#endif //DATA_COLLECTOR_LINUXFREADER_H

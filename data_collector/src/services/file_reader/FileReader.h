//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_FILEREADER_H
#define DATA_COLLECTOR_FILEREADER_H
#include <iostream>

using namespace std;
class FileReader{
public:
    virtual stringstream readFile(string filePath) = 0 ;
private:
};

#endif //DATA_COLLECTOR_FILEREADER_H

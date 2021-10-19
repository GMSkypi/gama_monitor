//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_FILEREADER_H
#define DATA_COLLECTOR_FILEREADER_H
#include <iostream>

class FileReader{
public:
    [[nodiscard]] virtual std::stringstream readFile(const std::string & filePath) const = 0 ;
private:
};

#endif //DATA_COLLECTOR_FILEREADER_H

//
// Created by gama on 01.04.22.
//

#ifndef DATA_COLLECTOR_DBCONTROLLER_H
#define DATA_COLLECTOR_DBCONTROLLER_H


#include "../obj/Container.h"

class DBController {
public :
    virtual void insertMetrics(const std::vector<Container>& containers) = 0;
    virtual void initContainer(Container & containers) = 0;
};


#endif //DATA_COLLECTOR_DBCONTROLLER_H

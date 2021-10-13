//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_CONTAINER_H
#define DATA_COLLECTOR_CONTAINER_H

#include <string>
#include <map>
#include "../constants/Enums.h"

using namespace std;

class Container {
private:
    string id;
    string name;
    unsigned pid;
    string image;
    map<Metrics,unsigned> lastMetrics;
    map<Paths,string> metricsPaths;
public:
    Container();
    Container(string id, string name, unsigned pid, string image);

    string getId();
    string getName();
    unsigned getPid();
    string getImage();
    map<Metrics,unsigned> getLastMetrics();
    void setLastMetrics(map<Metrics,unsigned> metrics);

    map<Paths,string> getMetricsPath();
    void setMetricsPath(map<Paths,string> paths);
};


#endif //DATA_COLLECTOR_CONTAINER_H

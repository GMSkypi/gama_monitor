//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_CONTAINER_H
#define DATA_COLLECTOR_CONTAINER_H

#include <string>
#include <map>
#include "../../constants/Enums.h"
#include <vector>
#include "ContainerInterface.h"

class Container {
private:
    std::string id;
    std::string name;
    unsigned pid;
    std::string image;
    std::map<constants::metrics::Metrics,unsigned long> lastMetrics;
    std::map<constants::Paths,std::string> metricsPaths;
    //std::vector<ContainerInterface> interfaces;
public:
    Container(const std::string& id, const std::string& name, unsigned pid, const std::string& image);

    void setPid(unsigned pid);
    [[nodiscard]] std::string getId() const;
    [[nodiscard]] std::string getName() const;
    [[nodiscard]] unsigned getPid() const;
    [[nodiscard]] std::string getImage() const;
    [[nodiscard]] std::map<constants::metrics::Metrics,unsigned long> & getLastMetrics();
    void setLastMetrics(const std::map<constants::metrics::Metrics,unsigned long> & metrics);

    [[nodiscard]] std::map<constants::Paths,std::string> getMetricsPath() const;
    void setMetricsPath(std::map<constants::Paths,std::string> & paths);
};


#endif //DATA_COLLECTOR_CONTAINER_H

//
// Created by gama on 06.10.21.
//

#ifndef DATA_COLLECTOR_CONTAINER_H
#define DATA_COLLECTOR_CONTAINER_H

#include <string>
#include <map>
#include "../../constants/Enums.h"
#include <vector>


class Container {
private:
    std::string id;
    std::vector<std::string> names;
    unsigned pid;
    std::string image;
    std::map<constants::metrics::Metrics,unsigned long> lastMetrics;
    std::map<constants::Paths,std::string> metricsPaths;
public:
    Container(const std::string& id, const std::vector<std::string>& names, unsigned pid, const std::string& image);

    void setPid(unsigned pid);
    [[nodiscard]] std::string getId() const;
    [[nodiscard]] std::vector<std::string> getNames() const;
    [[nodiscard]] unsigned getPid() const;
    [[nodiscard]] std::string getImage() const;
    [[nodiscard]] std::map<constants::metrics::Metrics,unsigned long> & getLastMetrics();
    void setLastMetrics(const std::map<constants::metrics::Metrics,unsigned long> & metrics);

    [[nodiscard]] std::map<constants::Paths,std::string> getMetricsPath() const;
    void setMetricsPath(std::map<constants::Paths,std::string> & paths);
};


#endif //DATA_COLLECTOR_CONTAINER_H

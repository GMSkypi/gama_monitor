//
// Created by gama on 06.10.21.
//

#include "Container.h"


Container::Container(const std::string& id, const std::vector<std::string>& names, unsigned int pid, const std::string& image) {
    this->id = id;
    this->names = names;
    this->pid = pid;
    this->image = image;
}

void Container::setPid(unsigned int newPid) {
    this->pid = newPid;
}

std::string Container::getId() const {
    return id;
}

std::vector<std::string> Container::getNames() const {
    return names;
}

unsigned Container::getPid() const {
    return pid;
}

std::string Container::getImage() const {
    return image;
}

std::map<constants::metrics::Metrics, unsigned long> & Container::getLastMetrics()  {
    return lastMetrics;
}

void Container::setLastMetrics(const std::map<constants::metrics::Metrics, unsigned long> &metrics) {
    lastMetrics = metrics;
}

std::map<constants::Paths, std::string> Container::getMetricsPath() const {
    return metricsPaths;
}

void Container::setMetricsPath(std::map<constants::Paths, std::string> &paths) {
    metricsPaths = paths;
}

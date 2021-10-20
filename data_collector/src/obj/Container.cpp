//
// Created by gama on 06.10.21.
//

#include "Container.h"


Container::Container(const std::string& id, const std::string& name, unsigned int pid, const std::string& image) {
    this->id = id;
    this->name = name;
    this->pid = pid;
    this->image = image;
}

void Container::setPid(unsigned int newPid) {
    this->pid = newPid;
}

std::string Container::getId() const {
    return id;
}

std::string Container::getName() const {
    return name;
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

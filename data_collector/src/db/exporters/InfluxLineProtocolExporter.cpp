//
// Created by gama on 18.11.21.
//

#include "InfluxLineProtocolExporter.h"

InfluxLineProtocolExporter::InfluxLineProtocolExporter() {

}

InfluxLineProtocolExporter &InfluxLineProtocolExporter::addAttribute(const std::string &name, unsigned long value) {
    if(!attributes.empty()) attributes += ",";
    attributes += name + "=" + std::to_string(value) + "i";
    return *this;
}

InfluxLineProtocolExporter &InfluxLineProtocolExporter::addAttribute(const std::string &name, const std::string& value) {
    if(!attributes.empty()) attributes += ",";
    attributes += name + "=\"" + value + "\"";
    return *this;
}

InfluxLineProtocolExporter &InfluxLineProtocolExporter::addTableName(const std::string &name) {
    table = name;
    return *this;
}

InfluxLineProtocolExporter &InfluxLineProtocolExporter::addTimestamp(const std::string &time) {
    timestamp = " " + time;
    return *this;
}

InfluxLineProtocolExporter &InfluxLineProtocolExporter::addTag(const std::string &name, const std::string &value) {
    tag = name + "=" + value + "";
    return *this;
}

std::string InfluxLineProtocolExporter::exportData() {
    return table + "," + tag + " " + attributes + timestamp + "\n";
}

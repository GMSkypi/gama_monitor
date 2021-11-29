//
// Created by gama on 18.11.21.
//

#ifndef DATA_COLLECTOR_INFLUXLINEPROTOCOLEXPORTER_H
#define DATA_COLLECTOR_INFLUXLINEPROTOCOLEXPORTER_H


#include <string>

class InfluxLineProtocolExporter {
private:
    std::string attributes;
    std::string table;
    std::string timestamp;
    std::string tag;

public :
    InfluxLineProtocolExporter();
    InfluxLineProtocolExporter & addAttribute(const std::string & name , unsigned long value);
    InfluxLineProtocolExporter & addAttribute(const std::string & name , const std::string& value);
    InfluxLineProtocolExporter & addTableName(const std::string & name);
    InfluxLineProtocolExporter & addTimestamp(const std::string & time);
    InfluxLineProtocolExporter & addTag(const std::string & name, const std::string & value);
    std::string exportData();
};


#endif //DATA_COLLECTOR_INFLUXLINEPROTOCOLEXPORTER_H

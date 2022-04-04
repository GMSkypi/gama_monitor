#include "gtest/gtest.h"
#include "../src/db/exporters/InfluxLineProtocolExporter.h"


TEST(InflixLineProtocolExporterTest, Syntax) {
    InfluxLineProtocolExporter exporter = InfluxLineProtocolExporter();
    exporter.addTableName("CPU");
    exporter.addTag("id","gm");
    exporter.addAttribute("kernel",10);
    exporter.addAttribute("user",10);
    exporter.addAttribute("test","test");
    exporter.addTimestamp("123456789");

    EXPECT_EQ("CPU,id=gm kernel=10i,user=10i,test=\"test\" 123456789\n",exporter.exportData());
}

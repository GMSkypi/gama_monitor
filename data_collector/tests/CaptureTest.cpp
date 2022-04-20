//
// Created by gama on 01.04.22.
//
#include "gtest/gtest.h"
#include "gmock/gmock.h"
#include "../src/services/MetricsParserFactory.h"
#include "../constants/Enums.h"
#include "../src/services/file_reader/FileReader.h"
#include "../src/Capture.h"

using ::testing::Return;
using ::testing::AtLeast;

class MockFileReader : public FileReader {
public:
    [[nodiscard]] std::stringstream readFile(const std::string & filePath) const override{
        if(filePath == "/pathToCPU"){
            return std::stringstream("123");
        }
        return {};
    }
};

TEST(CaptureTest, newCapture) {
    std::vector<MetricsParserFactory::metricParserVP> globalUnCapturedMetrics;
    std::map<constants::Paths,std::string> globalPaths;
    std::shared_ptr<MockFileReader> fileReader = std::make_shared<MockFileReader>();

    Capture capture(globalUnCapturedMetrics,globalPaths,fileReader);
    Container c = Container("dockerId_45864616",{},1,"ContainerImage");
    std::map<constants::Paths,std::string> metricsPaths;
    metricsPaths[constants::Paths::CPU_PROC_TOTAL] = "/pathToCPU";
    c.setMetricsPath(metricsPaths);

    MetricsParserFactory metricsFactory;
    metricsFactory.addCPUProcTotal();
    const std::vector<MetricsParserFactory::metricParserVP> unCapturedMetrics = metricsFactory.getMetricSources();

    capture.newCapture(c,unCapturedMetrics);
    EXPECT_EQ(123,c.getLastMetrics().at(constants::metrics::Metrics::CPU_PROC_TOTAL));
}

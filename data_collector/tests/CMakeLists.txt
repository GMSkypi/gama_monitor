# 'Google_test' is the subproject name
cmake_minimum_required(VERSION 3.20)
project(tests)

# 'lib' is the folder with Google Test sources
add_subdirectory(lib/googletest)
include_directories(${gtest_SOURCE_DIR}/include ${gtest_SOURCE_DIR})



add_executable(Tests_run InfluxLineProtocolExporter.cpp DockerAPIParserTest.cpp ../constants/LinuxSourcePaths.h ../src/services/file_reader/FileReader.h ../src/services/file_reader/LinuxFReader.h ../src/services/file_reader/LinuxFReader.cpp ../src/Capture.cpp ../src/Capture.h ../src/obj/Container.cpp ../src/obj/Container.h ../constants/Enums.h ../src/services/path_generator/PathGenerator.h ../src/services/path_generator/LinuxPathGenerator.cpp ../src/services/path_generator/LinuxPathGenerator.h ../src/services/exec/docker_exec/ShellDockerExec.cpp ../src/services/exec/docker_exec/ShellDockerExec.h ../src/Collector.cpp ../src/Collector.h ../constants/LinuxBashCommands.h ../src/services/explorer/ContainerExplorer.h ../src/services/MetricsParserFactory.cpp ../src/services/MetricsParserFactory.h ../src/parsers/metric_parsers/MetricParser.h ../src/services/explorer/ContainerExplorer.cpp ../src/services/exec/docker_exec/DockerExecutor.h ../src/parsers/StringParser.cpp ../src/parsers/StringParser.h ../src/parsers/metric_parsers/MetricParsersImp.cpp ../src/services/exec/docker_exec/CurlDockerExec.cpp ../src/services/exec/docker_exec/CurlDockerExec.h ../constants/DockerAPICommands.h ../src/parsers/DockerParser.h ../src/parsers/DockerBashParser.cpp ../src/parsers/DockerBashParser.h ../src/parsers/DockerAPIParser.cpp ../src/parsers/DockerAPIParser.h ../src/obj/Config.h ../src/services/iniLoader/IniLoader.cpp ../src/services/iniLoader/IniLoader.h ../src/services/Timer.cpp ../src/services/Timer.h ../src/db/exporters/InfluxLineProtocolExporter.cpp ../src/db/exporters/InfluxLineProtocolExporter.h ../src/services/exec/CurlExec.cpp ../src/services/exec/CurlExec.h ../src/services/exec/ShellExec.cpp ../src/services/exec/ShellExec.h ../src/services/exec/SocketExec.cpp ../src/services/exec/SocketExec.h ../src/services/exec/Executor.h ../src/db/QDBController.cpp ../src/db/QDBController.h ../src/parsers/QDBAPIParser.cpp ../src/parsers/QDBAPIParser.h QDBAPIParserTest.cpp StringParserTest.cpp ContainerExplorerTest.cpp ../src/db/DBController.h CaptureTest.cpp)

target_link_libraries(Tests_run gtest gtest_main gmock curl)

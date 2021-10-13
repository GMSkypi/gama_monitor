cmake_minimum_required(VERSION 3.20)
project(data_collector)

set(CMAKE_CXX_STANDARD 17)

add_executable(data_collector src/main.cpp constants/LinuxSourcePaths.h src/services/file_reader/FileReader.h src/services/file_reader/LinuxFReader.h src/services/file_reader/LinuxFReader.cpp src/services/Capture.cpp src/services/Capture.h src/Container.cpp src/Container.h constants/Enums.h src/services/path_generator/PathGenerator.h src/services/path_generator/LinuxPathGenerator.cpp src/services/path_generator/LinuxPathGenerator.h src/services/ShellExec.cpp src/services/ShellExec.h)

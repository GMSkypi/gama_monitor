#include <iostream>
#include <sstream>
#include "services/ShellExec.h"
#include "services/file_reader/LinuxFReader.h"
#include "services/path_generator/LinuxPathGenerator.h"
using namespace std;
int main() {


  // load config
  //
  // start capturing
  cout << ShellExec().exec("docker ps --no-trunc");
  string file = LinuxPathGenerator().getMemoryPath("5aa30d8a45743cba9eb75f52bb6c52c5fb96c4a7346f996147b361e6523c2ef3");
  stringstream stream = LinuxFReader().readFile(file);
  cout << stream.str();
  return 0;
}

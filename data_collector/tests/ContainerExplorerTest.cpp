//
// Created by gama on 01.04.22.
//
#include "gtest/gtest.h"
#include "../src/services/exec/docker_exec/DockerExecutor.h"
#include "gmock/gmock.h"
#include "../src/parsers/DockerParser.h"
#include "../src/services/path_generator/PathGenerator.h"
#include "../src/services/path_generator/LinuxPathGenerator.h"
#include "../src/parsers/DockerAPIParser.h"
#include "../src/services/explorer/ContainerExplorer.h"

#include <memory>
#include <utility>
using ::testing::Return;
using ::testing::AtLeast;

class MockDockerExecutor : public DockerExecutor {
public:
    MOCK_METHOD(string, getPid, (const string & containerID), (override));
    MOCK_METHOD(string, getContainers, (), (override));
};

class MockDBController : public DBController {
public:
    MOCK_METHOD(void, insertMetrics, (const std::vector<Container>& containers), (override));
    MOCK_METHOD(void, initContainer, (Container & containers), (override));
};


class ContainerExplorerFixture : public ::testing::Test {
protected:
    virtual void SetUp()
    {
        executor = std::make_shared<MockDockerExecutor>();
        parser = shared_ptr<parser::DockerParser>(new parser::DockerAPIParser);
        pathGenerator = shared_ptr<PathGenerator>(new LinuxPathGenerator());
        controller = std::make_shared<MockDBController>();

        string data = "[{\"Id\":\"1d918f6bc1b50171eb2cc56676eb93f32e860749df80aa364e71d9a718cc3c6e\",\"Names\":[\"/questdb\"],\"Image\":\"questdb/questdb:latest\",\"ImageID\":\"sha256:dc44e204527a798249983a414d50e7bd135ae89144946b7a79b576c856530052\",\"Command\":\"/usr/bin/env QDB_PACKAGE=docker /app/bin/java -Dout=conf/log.conf -m io.questdb/io.questdb.ServerMain -d /root/.questdb -f\",\"Created\":1645877521,\"Ports\":[{\"IP\":\"0.0.0.0\",\"PrivatePort\":9009,\"PublicPort\":9009,\"Type\":\"tcp\"},{\"IP\":\"::\",\"PrivatePort\":9009,\"PublicPort\":9009,\"Type\":\"tcp\"},{\"IP\":\"0.0.0.0\",\"PrivatePort\":8812,\"PublicPort\":8812,\"Type\":\"tcp\"},{\"IP\":\"::\",\"PrivatePort\":8812,\"PublicPort\":8812,\"Type\":\"tcp\"},{\"IP\":\"0.0.0.0\",\"PrivatePort\":9000,\"PublicPort\":9000,\"Type\":\"tcp\"},{\"IP\":\"::\",\"PrivatePort\":9000,\"PublicPort\":9000,\"Type\":\"tcp\"},{\"IP\":\"0.0.0.0\",\"PrivatePort\":9003,\"PublicPort\":9003,\"Type\":\"tcp\"},{\"IP\":\"::\",\"PrivatePort\":9003,\"PublicPort\":9003,\"Type\":\"tcp\"}],\"Labels\":{\"com.docker.compose.config-hash\":\"14b1d7dc20874944fa2ee95f0db645f5ffdcdb94a5a9e52041145c05ee563d78\",\"com.docker.compose.container-number\":\"1\",\"com.docker.compose.oneoff\":\"False\",\"com.docker.compose.project\":\"gama_monitor\",\"com.docker.compose.project.config_files\":\"docker-compose.yml\",\"com.docker.compose.project.working_dir\":\"/home/gama/gama_monitor\",\"com.docker.compose.service\":\"database-service\",\"com.docker.compose.version\":\"1.29.2\"},\"State\":\"running\",\"Status\":\"Up 23 hours\",\"HostConfig\":{\"NetworkMode\":\"gama_monitor_gama_network\"},\"NetworkSettings\":{\"Networks\":{\"gama_monitor_gama_network\":{\"IPAMConfig\":null,\"Links\":null,\"Aliases\":null,\"NetworkID\":\"e3ba78f2e04f00fd00f10674431a72f87694981c4d1ad57331e5e0e362ec761c\",\"EndpointID\":\"3ff2739a8bcdb571e09e8877ee13884137e7e3819537c205fe0c18e405449c76\",\"Gateway\":\"172.19.0.1\",\"IPAddress\":\"172.19.0.2\",\"IPPrefixLen\":16,\"IPv6Gateway\":\"\",\"GlobalIPv6Address\":\"\",\"GlobalIPv6PrefixLen\":0,\"MacAddress\":\"02:42:ac:13:00:02\",\"DriverOpts\":null}}},\"Mounts\":[{\"Type\":\"bind\",\"Source\":\"/home/gama/gama_monitor/questDB\",\"Destination\":\"/root/.questdb\",\"Mode\":\"rw\",\"RW\":true,\"Propagation\":\"rprivate\"}]},{\"Id\":\"5aa30d8a45743cba9eb75f52bb6c52c5fb96c4a7346f996147b361e6523c2ef3\",\"Names\":[\"/dapr_zipkin\"],\"Image\":\"openzipkin/zipkin\",\"ImageID\":\"sha256:9b4acc3eb019316ab28b3e3bad032af26c1a2d38576a6345e0c5516c11c078c0\",\"Command\":\"start-zipkin\",\"Created\":1626539314,\"Ports\":[{\"IP\":\"0.0.0.0\",\"PrivatePort\":9411,\"PublicPort\":9411,\"Type\":\"tcp\"},{\"IP\":\"::\",\"PrivatePort\":9411,\"PublicPort\":9411,\"Type\":\"tcp\"},{\"PrivatePort\":9410,\"Type\":\"tcp\"}],\"Labels\":{\"alpine-version\":\"3.12.3\",\"java-home\":\"/usr/lib/jvm/java-15-openjdk\",\"java-version\":\"15.0.1_p9\",\"maintainer\":\"OpenZipkin https://gitter.im/openzipkin/zipkin\",\"org.opencontainers.image.authors\":\"OpenZipkin https://gitter.im/openzipkin/zipkin\",\"org.opencontainers.image.created\":\"2020-12-25\",\"org.opencontainers.image.description\":\"Zipkin full distribution on OpenJDK and Alpine Linux\",\"org.opencontainers.image.revision\":\"7bf3aab83\"},\"State\":\"running\",\"Status\":\"Up 46 hours (healthy)\",\"HostConfig\":{\"NetworkMode\":\"default\"},\"NetworkSettings\":{\"Networks\":{\"bridge\":{\"IPAMConfig\":null,\"Links\":null,\"Aliases\":null,\"NetworkID\":\"8d8c0626a6444d51366594f206ad1b623a23b815612c0e7fb049c14f6162d61c\",\"EndpointID\":\"a65702de3761cd84ee60b36893583db48241175a0461fc3a8e3d85b851601708\",\"Gateway\":\"172.17.0.1\",\"IPAddress\":\"172.17.0.4\",\"IPPrefixLen\":16,\"IPv6Gateway\":\"\",\"GlobalIPv6Address\":\"\",\"GlobalIPv6PrefixLen\":0,\"MacAddress\":\"02:42:ac:11:00:04\",\"DriverOpts\":null}}},\"Mounts\":[]},{\"Id\":\"05e8ea9e1d667b7fd327abc4f197218a11ecc289f49cc8066dc323ac4f70c0e5\",\"Names\":[\"/dapr_redis\"],\"Image\":\"redis\",\"ImageID\":\"sha256:08502081bff61084d64fc76f0f90ea39b89935cd071d9e12c5374ae191ff53c0\",\"Command\":\"docker-entrypoint.sh redis-server\",\"Created\":1626539313,\"Ports\":[{\"IP\":\"0.0.0.0\",\"PrivatePort\":6379,\"PublicPort\":6379,\"Type\":\"tcp\"},{\"IP\":\"::\",\"PrivatePort\":6379,\"PublicPort\":6379,\"Type\":\"tcp\"}],\"Labels\":{},\"State\":\"running\",\"Status\":\"Up 46 hours\",\"HostConfig\":{\"NetworkMode\":\"default\"},\"NetworkSettings\":{\"Networks\":{\"bridge\":{\"IPAMConfig\":null,\"Links\":null,\"Aliases\":null,\"NetworkID\":\"8d8c0626a6444d51366594f206ad1b623a23b815612c0e7fb049c14f6162d61c\",\"EndpointID\":\"f6ad299da1551233fa81bdf0ae0cbdb4c30500133b5d9b1d9d4457255c7571af\",\"Gateway\":\"172.17.0.1\",\"IPAddress\":\"172.17.0.3\",\"IPPrefixLen\":16,\"IPv6Gateway\":\"\",\"GlobalIPv6Address\":\"\",\"GlobalIPv6PrefixLen\":0,\"MacAddress\":\"02:42:ac:11:00:03\",\"DriverOpts\":null}}},\"Mounts\":[{\"Type\":\"volume\",\"Name\":\"e383b95e211d8ce0301c81914b6494d16ff189aa96f47f64a019b517672b0a32\",\"Source\":\"\",\"Destination\":\"/data\",\"Driver\":\"local\",\"Mode\":\"\",\"RW\":true,\"Propagation\":\"\"}]},{\"Id\":\"98ef9eeaa01eef8a2e9cf93dd0c04d76557e2167d686e08a582991713a2046af\",\"Names\":[\"/dapr_placement\"],\"Image\":\"daprio/dapr\",\"ImageID\":\"sha256:91d6b4103e096137665f77e16ce7aee56f827e3e1b90e2adfaee68a1fac7555f\",\"Command\":\"./placement\",\"Created\":1626539303,\"Ports\":[{\"IP\":\"0.0.0.0\",\"PrivatePort\":50005,\"PublicPort\":50005,\"Type\":\"tcp\"},{\"IP\":\"::\",\"PrivatePort\":50005,\"PublicPort\":50005,\"Type\":\"tcp\"}],\"Labels\":{},\"State\":\"running\",\"Status\":\"Up 46 hours\",\"HostConfig\":{\"NetworkMode\":\"default\"},\"NetworkSettings\":{\"Networks\":{\"bridge\":{\"IPAMConfig\":null,\"Links\":null,\"Aliases\":null,\"NetworkID\":\"8d8c0626a6444d51366594f206ad1b623a23b815612c0e7fb049c14f6162d61c\",\"EndpointID\":\"12d7cc94fe27e886d055b52bb1f7a2285582828f1c716e2b31041dbe63cc560d\",\"Gateway\":\"172.17.0.1\",\"IPAddress\":\"172.17.0.2\",\"IPPrefixLen\":16,\"IPv6Gateway\":\"\",\"GlobalIPv6Address\":\"\",\"GlobalIPv6PrefixLen\":0,\"MacAddress\":\"02:42:ac:11:00:02\",\"DriverOpts\":null}}},\"Mounts\":[]}]\n";
        string pid = "{\"Processes\":[[\"root\",\"242021\",\"241997\",\"17\",\"10:53\",\"?\",\"00:21:42\",\"/app/bin/java -Dout=conf/log.conf -m io.questdb/io.questdb.ServerMain -d /root/.questdb -f\"]],\"Titles\":[\"UID\",\"PID\",\"PPID\",\"C\",\"STIME\",\"TTY\",\"TIME\",\"CMD\"]}\n";
        EXPECT_CALL(*executor, getContainers()).WillOnce(Return(data));
        EXPECT_CALL(*executor, getPid(testing::_)).WillRepeatedly(Return(pid));
    }
    std::shared_ptr<MockDockerExecutor> executor;
    std::shared_ptr<parser::DockerParser> parser;
    std::shared_ptr<PathGenerator> pathGenerator;
    std::shared_ptr<MockDBController> controller;
};

TEST_F(ContainerExplorerFixture, exploreTest) {

    vector<string> blackList = {""};
    EXPECT_CALL(*controller, initContainer(testing::_)).Times(AtLeast(4));
    ContainerExplorer explorer = ContainerExplorer(executor,parser,pathGenerator,blackList);
    vector<Container> exploredContainers = explorer.explore(controller);


    EXPECT_EQ(4,exploredContainers.size());
    EXPECT_EQ(242021,exploredContainers[0].getPid());
    EXPECT_EQ("questdb/questdb:latest",exploredContainers[0].getImage());
    EXPECT_EQ("openzipkin/zipkin",exploredContainers[1].getImage());
    EXPECT_EQ("redis",exploredContainers[2].getImage());
    EXPECT_EQ("daprio/dapr",exploredContainers[3].getImage());
}
TEST_F(ContainerExplorerFixture, exploreNewTest) {
    vector<string> blackList = {""};

    EXPECT_CALL(*controller, initContainer(testing::_)).Times(AtLeast(4));
    ContainerExplorer explorer = ContainerExplorer(executor,parser,pathGenerator,blackList);
    vector<Container> containers = {};

    explorer.exploreNew(containers,controller);
    EXPECT_EQ(4,containers.size());
    EXPECT_EQ(242021,containers[0].getPid());
    EXPECT_EQ("questdb/questdb:latest",containers[0].getImage());
    EXPECT_EQ("openzipkin/zipkin",containers[1].getImage());
    EXPECT_EQ("redis",containers[2].getImage());
    EXPECT_EQ("daprio/dapr",containers[3].getImage());
}
TEST_F(ContainerExplorerFixture, exploreNewWithExistingCTest) {
    vector<string> blackList = {""};
    EXPECT_CALL(*controller, initContainer(testing::_)).Times(AtLeast(3));
    ContainerExplorer explorer = ContainerExplorer(executor,parser,pathGenerator,blackList);
    vector<Container> containers = {Container("1d918f6bc1b50171eb2cc56676eb93f32e860749df80aa364e71d9a718cc3c6e",{},10,"questdb/questdb:latest")};

    explorer.exploreNew(containers,controller);
    EXPECT_EQ(4,containers.size());
    EXPECT_EQ(10,containers[0].getPid());
    EXPECT_EQ("questdb/questdb:latest",containers[0].getImage());
    EXPECT_LE(1,containers[0].getMetricsPath().size());
    EXPECT_EQ("openzipkin/zipkin",containers[1].getImage());
    EXPECT_EQ("redis",containers[2].getImage());
    EXPECT_EQ("daprio/dapr",containers[3].getImage());
}
TEST_F(ContainerExplorerFixture, exploreNewDeleteCTest) {
    vector<string> blackList = {""};
    EXPECT_CALL(*controller, initContainer(testing::_)).Times(AtLeast(4));
    ContainerExplorer explorer = ContainerExplorer(executor,parser,pathGenerator,blackList);
    vector<Container> containers = {Container("aefgawgf",{},10,"existingContainer")};

    explorer.exploreNew(containers,controller);
    EXPECT_EQ(4,containers.size());
    EXPECT_EQ(242021,containers[0].getPid());
    EXPECT_LE(1,containers[0].getMetricsPath().size());
    EXPECT_EQ("questdb/questdb:latest",containers[0].getImage());
    EXPECT_EQ("openzipkin/zipkin",containers[1].getImage());
    EXPECT_EQ("redis",containers[2].getImage());
    EXPECT_EQ("daprio/dapr",containers[3].getImage());
}
TEST_F(ContainerExplorerFixture, exploreNewBlackListTest) {
    vector<string> blackList = {"daprio/dapr", "redis"};
    EXPECT_CALL(*controller, initContainer(testing::_)).Times(AtLeast(3));
    ContainerExplorer explorer = ContainerExplorer(executor,parser,pathGenerator,blackList);
    vector<Container> containers = {};

    explorer.exploreNew(containers,controller);
    EXPECT_EQ(2,containers.size());
    EXPECT_EQ(242021,containers[0].getPid());
    EXPECT_LE(1,containers[0].getMetricsPath().size());
    EXPECT_EQ("questdb/questdb:latest",containers[0].getImage());
    EXPECT_EQ("openzipkin/zipkin",containers[1].getImage());
}
TEST_F(ContainerExplorerFixture, exploreBlackListTest) {
    vector<string> blackList = {"daprio/dapr"};
    EXPECT_CALL(*controller, initContainer(testing::_)).Times(AtLeast(3));
    ContainerExplorer explorer = ContainerExplorer(executor,parser,pathGenerator,blackList);

    vector<Container> exploredContainers = explorer.explore(controller);
    EXPECT_EQ(3,exploredContainers.size());
    EXPECT_EQ(242021,exploredContainers[0].getPid());
    EXPECT_LE(1,exploredContainers[0].getMetricsPath().size());
    EXPECT_EQ("questdb/questdb:latest",exploredContainers[0].getImage());
    EXPECT_EQ("openzipkin/zipkin",exploredContainers[1].getImage());
    EXPECT_EQ("redis",exploredContainers[2].getImage());
}
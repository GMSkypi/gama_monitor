//
// Created by gama on 20.11.21.
//

#ifndef DATA_COLLECTOR_QDBCONTROLLER_H
#define DATA_COLLECTOR_QDBCONTROLLER_H


#include "../obj/Container.h"
#include "../services/exec/SocketExec.h"
#include "../services/exec/CurlExec.h"
#include "../parsers/QDBAPIParser.h"
#include "../obj/Config.h"

class QDBController {
private:
    SocketExec socExecutor = SocketExec("127.0.0.1",true,9009); // TODO sharedptr because params
    CurlExec curlExecutor = CurlExec();
    parser::QDBAPIParser parser = parser::QDBAPIParser();
    std::shared_ptr<Config> conf;
public:
    QDBController(std::shared_ptr<Config> conf);
    void insertMetrics(const std::vector<Container>& containers); // socket
    void initContainer(Container & containers); // curl // socket
private:
    unsigned long defaultIfNotExists(const std::map<constants::metrics::Metrics, unsigned long> & metrics,
                                 constants::metrics::Metrics toFind);
};


#endif //DATA_COLLECTOR_QDBCONTROLLER_H

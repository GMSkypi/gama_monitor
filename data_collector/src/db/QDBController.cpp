//
// Created by gama on 20.11.21.
//

#include "QDBController.h"

#include <utility>
#include "exporters/InfluxLineProtocolExporter.h"

using namespace constants::metrics;
void QDBController::initContainer(Container &container) {
    container.setUniqueID(container.getImage());
    std::string containerIDJson = curlExecutor.exec("http://localhost:9000/exec",
                                                              ("select id from Container where id = '" + container.getUniqueID() + "'").c_str());
    unsigned count = parser.parseNumberOfColumn(containerIDJson);
    if(count == 0){
        InfluxLineProtocolExporter exporter;
        exporter
        .addTableName("Container")
        .addTag("id",container.getUniqueID())
        .addAttribute("docekr_id", container.getId())
        .addAttribute("names", container.getNamesInSingleString())
        .addAttribute("image", container.getImage());
        socExecutor.init();
        socExecutor.exec(exporter.exportData().c_str());
        socExecutor.exit();
    }
}

void QDBController::insertMetrics(const std::vector<Container>& containers) {
    socExecutor.init();
    for(const Container & container : containers){
        const std::map<constants::metrics::Metrics, unsigned long> & metrics = container.getLastMetrics();
        InfluxLineProtocolExporter exporter;
        exporter
                .addTableName("CPU")
                .addTimestamp(std::to_string(container.getTimestamp().count()))
                .addTag("Container_id",container.getUniqueID())
                .addAttribute("u_space_pr",defaultIfNotExists(metrics,Metrics::CPU_USER))
                .addAttribute("k_space_pr",defaultIfNotExists(metrics,Metrics::CPU_KERNEL))
                .addAttribute("u_space_ms",defaultIfNotExists(metrics,Metrics::CPU_USER_TIME))
                .addAttribute("k_space_ms",defaultIfNotExists(metrics,Metrics::CPU_KERNEL_TIME))
                .addAttribute("throttle_ns",defaultIfNotExists(metrics,Metrics::THROTTLE_TIME))
                .addAttribute("throttle_cnt",defaultIfNotExists(metrics,Metrics::THROTTLE_COUNT))
                .addAttribute("total_ns",defaultIfNotExists(metrics,Metrics::CPU_PROC_TIME))
                .addAttribute("total_pr",defaultIfNotExists(metrics,Metrics::CPU_PROC));
        socExecutor.exec(exporter.exportData().c_str());

        exporter = InfluxLineProtocolExporter();
        exporter
                .addTableName("Memory")
                .addTimestamp(std::to_string(container.getTimestamp().count()))
                .addTag("Container_id",container.getUniqueID())
                .addAttribute("mem_used",defaultIfNotExists(metrics,Metrics::MEM_USED))
                .addAttribute("mem_swap_used",defaultIfNotExists(metrics,Metrics::MEM_USED_SWAP))
                .addAttribute("rss",defaultIfNotExists(metrics,Metrics::MEM_RSS))
                .addAttribute("cacheC",defaultIfNotExists(metrics,Metrics::MEM_CACHE))
                .addAttribute("swap",defaultIfNotExists(metrics,Metrics::MEM_SWAP))
                .addAttribute("mem_limit",defaultIfNotExists(metrics,Metrics::MEM_LIMIT))
                .addAttribute("mem_swap_limit",defaultIfNotExists(metrics,Metrics::MEM_SWAP_LIMIT))
                .addAttribute("mem_hit_cnt",defaultIfNotExists(metrics,Metrics::MEM_HIT_COUNT))
                .addAttribute("mem_swap_hit_cnt",defaultIfNotExists(metrics,Metrics::MEM_SWAP_HIT_COUNT));
        socExecutor.exec(exporter.exportData().c_str());

        exporter = InfluxLineProtocolExporter();
        exporter
                .addTableName("IO")
                .addTimestamp(std::to_string(container.getTimestamp().count()))
                .addTag("Container_id",container.getUniqueID())
                .addAttribute("read",defaultIfNotExists(metrics,Metrics::IO_READ))
                .addAttribute("write",defaultIfNotExists(metrics,Metrics::IO_WRITE));
        socExecutor.exec(exporter.exportData().c_str());

        exporter = InfluxLineProtocolExporter();
        exporter
                .addTableName("NET")
                .addTimestamp(std::to_string(container.getTimestamp().count()))
                .addTag("Container_id",container.getUniqueID())
                .addAttribute("receive",defaultIfNotExists(metrics,Metrics::NET_RECEIVE))
                .addAttribute("receive_error",defaultIfNotExists(metrics,Metrics::NET_RECEIVE_ERROR))
                .addAttribute("receive_error_total",defaultIfNotExists(metrics,Metrics::NET_RECEIVE_ERROR_ACC))
                .addAttribute("transmit",defaultIfNotExists(metrics,Metrics::NET_TRANSMIT))
                .addAttribute("transmit_error",defaultIfNotExists(metrics,Metrics::NET_TRANSMIT_ERROR))
                .addAttribute("transmit_error_total",defaultIfNotExists(metrics,Metrics::NET_TRANSMIT_ERROR_ACC));
        socExecutor.exec(exporter.exportData().c_str());
    }

    socExecutor.exit();
}

QDBController::QDBController(std::shared_ptr<Config> conf) {
    this->conf = std::move(conf);
}

unsigned long QDBController::defaultIfNotExists(const std::map<constants::metrics::Metrics, unsigned long> & metrics,
                                            constants::metrics::Metrics toFind) {
    auto search = metrics.find(toFind);
    return search != metrics.end() ? search->second : 0;
}

//
// Created by gama on 14.10.21.
//

#include "MetricsParserFactory.h"
#include "../parsers/metric_parsers/MetricParsersImp.cpp"

std::vector<MetricsParserFactory::metricParserVP> MetricsParserFactory::getMetricSources() const {
    return metricSources;
}

void MetricsParserFactory::addCPUUsage() {
    metricSources.push_back({
            constants::CPU_USAGE,
            std::shared_ptr<MetricParser>(new CpuUsageParser())});
}

void MetricsParserFactory::addCPUThrottle() {
    metricSources.push_back({
        constants::CPU_THROTTLE,
        std::shared_ptr<MetricParser>(new CpuThrottleParser())});
}

void MetricsParserFactory::addCPUProcTotal() {
    metricSources.push_back({
        constants::CPU_PROC_TOTAL,
        std::shared_ptr<MetricParser>(new CpuProcTotalParser())});
}

void MetricsParserFactory::addMemory() {
    metricSources.push_back({
        constants::MEM,
        std::shared_ptr<MetricParser>(new MemParser())});
}

void MetricsParserFactory::addMemoryTotal() {
    metricSources.push_back({
        constants::MEM_TOTAL,
        std::shared_ptr<MetricParser>(new MemTotalParser())});
}

void MetricsParserFactory::addMemorySwap() {
    metricSources.push_back({
        constants::MEM_TOTAL_SWAP,
        std::shared_ptr<MetricParser>(new MemTotalSwapParser())});
}

void MetricsParserFactory::addMemoryLimit() {
    metricSources.push_back({
        constants::MEM_LIMITS,
        std::shared_ptr<MetricParser>(new MemLimitsParser())});
}

void MetricsParserFactory::addMemoryLimitSwap() {
    metricSources.push_back({
        constants::MEM_LIMIT_SWAP,
        std::shared_ptr<MetricParser>(new MemTotalSwapParser())});
}

void MetricsParserFactory::addLimitHit() {
    metricSources.push_back({
        constants::MEM_COUNT_LIMHIT,
        std::shared_ptr<MetricParser>(new MemCountLimHitParser())});
}
void MetricsParserFactory::addLimitSwapHit(){
    metricSources.push_back({
        constants::MEM_SWAP_LIMHIT,
        std::shared_ptr<MetricParser>(new MemSwapLimitHitParser())});
}

void MetricsParserFactory::addNetwork() {
    metricSources.push_back({
        constants::NET,
        std::shared_ptr<MetricParser>(new NetParser())});
}

void MetricsParserFactory::addIO() {
    metricSources.push_back({
        constants::IO,
        std::shared_ptr<MetricParser>(new IOParser())});
}

void MetricsParserFactory::addAllMetrics() {
    addCPUUsage();
    addCPUThrottle();
    addCPUProcTotal();
    addMemory();
    addMemoryTotal();
    addMemorySwap();
    addMemoryLimit();
    addMemoryLimitSwap();
    addLimitHit();
    addLimitSwapHit();
    addNetwork();
    addIO();
}

//
// Created by gama on 16.10.21.
//
#include "MetricParser.h"
#include "../StringParser.h"

using namespace constants::metrics;
namespace metricParser{
    class CpuUsageParser : public MetricParser{
    public:
        void parse(const std::string &data,
                std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
            std::vector<std::string> result = parser::tokenize(data, std::regex("\\D+"));
            metrics[Metrics::CPU_USER_ACUM] = parser::getUnsignedFromString(result[0]);
            metrics[Metrics::CPU_KERNEL_ACUM] = parser::getUnsignedFromString(result[1]);
        }
    };
    class CpuThrottleParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
            std::vector<std::string> result = parser::tokenize(data, std::regex("\\D+"));
            metrics[Metrics::THROTTLE_COUNT] = parser::getUnsignedFromString(result[1]);
            metrics[Metrics::THROTTLE_TIME] = parser::getUnsignedFromString(result[2]);
        }
    };
    class CpuTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
            // TODO shell exec ... | file read ??
        }
    };
    class CpuProcTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
            metrics[Metrics::CPU_PROC_TOTAL] = parser::getUnsignedFromString(data);
        }
    };
    class MemParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
            std::vector<std::string> result = parser::tokenize(data, std::regex("\\D+"));
            metrics[Metrics::THROTTLE_COUNT] = parser::getUnsignedFromString(result[0]); // TODO
        }
    };
    class MemTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemTotalSwapParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemLimitsParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemLimitsSwapParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemCountLimHitParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemSwapLimitHitParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
        }
    };
    class IOParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
        }
    };
    class NetParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned>  & metrics ) override {
        }
    };
}

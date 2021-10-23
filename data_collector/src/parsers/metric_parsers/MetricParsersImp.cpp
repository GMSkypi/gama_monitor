//
// Created by gama on 16.10.21.
//
#include <iostream>
#include "MetricParser.h"
#include "../StringParser.h"

using namespace constants::metrics;
namespace metricParser{
    class CpuUsageParser : public MetricParser{
    public:
        void parse(const std::string &data,
                std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            std::vector<std::string> result = parser::tokenize(data, std::regex("\\D+"));
            metrics[Metrics::CPU_USER_ACUM] = parser::getUnsignedFromString(result[0]);
            metrics[Metrics::CPU_KERNEL_ACUM] = parser::getUnsignedFromString(result[1]);
        }
    };
    class CpuThrottleParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            std::vector<std::string> result = parser::tokenize(data, std::regex("\\D+"));
            metrics[Metrics::THROTTLE_COUNT] = parser::getUnsignedFromString(result[1]);
            metrics[Metrics::THROTTLE_TIME] = parser::getUnsignedFromString(result[2]);
        }
    };
    class CpuTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            std::string firstLine = parser::tokenize(data, std::regex("\\n"))[0];
            std::vector<std::string> result = parser::tokenize(firstLine, std::regex("\\D+"));
            unsigned long totalCpu = 0;
            for(const auto & value : result){
                totalCpu += parser::getUnsignedFromString(value);
            }
            metrics[CPU_TOTAL_ACUM] = totalCpu;
        }
    };
    class CpuProcTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            metrics[Metrics::CPU_PROC_TOTAL] = parser::getUnsignedFromString(data);
        }
    };
    class MemParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            std::vector<std::string> result = parser::tokenize(data, std::regex("\\D+"));
            metrics[Metrics::MEM_CACHE] = parser::getUnsignedFromString(result[19]);
            metrics[Metrics::MEM_RSS] = parser::getUnsignedFromString(result[20]);
            metrics[Metrics::MEM_SWAP] = parser::getUnsignedFromString(result[26]);
        }
    };
    class MemTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            metrics[Metrics::MEM_USED] = parser::getUnsignedFromString(data);
        }
    };
    class MemTotalSwapParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            metrics[Metrics::MEM_USED_SWAP] = parser::getUnsignedFromString(data);
        }
    };
    class MemLimitsParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            if(data.length() >= 17)
                metrics[Metrics::MEM_LIMIT] = 0;
            else
                metrics[Metrics::MEM_LIMIT] = parser::getUnsignedFromString(data);
        }
    };
    class MemLimitsSwapParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            if(data.length() >= 17)
                metrics[Metrics::MEM_SWAP_LIMIT] = 0;
            else
                metrics[Metrics::MEM_SWAP_LIMIT] = parser::getUnsignedFromString(data);
        }
    };
    class MemCountLimHitParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            metrics[Metrics::MEM_HIT_COUNT] = parser::getUnsignedFromString(data);
        }
    };
    class MemSwapLimitHitParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            metrics[Metrics::MEM_SWAP_HIT_COUNT] = parser::getUnsignedFromString(data);
        }
    };
    class IOParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            metrics[Metrics::IO_READ_ACC] = parser::getUnsignedFromString(
                    parser::firstMatchRegex(
                            parser::firstMatchRegex(data,regex("(Read )[0-9]*")),
                            regex("[0-9]+")));
            metrics[Metrics::IO_WRITE_ACC] = parser::getUnsignedFromString(
                    parser::firstMatchRegex(
                            parser::firstMatchRegex(data,regex("(Write )[0-9]*")),
                            regex("[0-9]+")));
        }
    };
    class NetParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::metrics::Metrics,unsigned long>  & metrics ) override {
            metrics[Metrics::NET_RECEIVE_ACC] = 0;
            metrics[Metrics::NET_RECEIVE_ERROR_ACC] = 0;
            metrics[Metrics::NET_TRANSMIT_ACC] = 0;
            metrics[Metrics::NET_TRANSMIT_ERROR_ACC] = 0;

            //auto matchLines = parser::matchRegex(data,regex("(([a-z]|[0-9])*:)(\\s+|[0-9])*"));
            auto matchLines = parser::tokenize(data,std::regex("\\n"));
            auto lineIter = matchLines.begin()+2;
            for(;lineIter < matchLines.end(); ++lineIter){
                std::vector<std::string> netMetrics = parser::tokenize(*lineIter, std::regex("\\s+|\\n"));
                if(netMetrics.size() != 17) continue;
                metrics[Metrics::NET_RECEIVE_ACC] +=  parser::getUnsignedFromString(netMetrics[1]);
                metrics[Metrics::NET_RECEIVE_ERROR_ACC] += parser::getUnsignedFromString(netMetrics[3]);
                metrics[Metrics::NET_TRANSMIT_ACC] += parser::getUnsignedFromString(netMetrics[9]);
                metrics[Metrics::NET_TRANSMIT_ERROR_ACC] += parser::getUnsignedFromString(netMetrics[11]);
            }
        }
    };
}

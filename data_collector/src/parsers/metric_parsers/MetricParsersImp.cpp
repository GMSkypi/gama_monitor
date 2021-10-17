//
// Created by gama on 16.10.21.
//
#include "MetricParser.h"

namespace metricParser{
    class CpuUsageParser : public MetricParser{
    public:
        void parse(const std::string &data,
                std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class CpuThrottleParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class CpuTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class CpuProcTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemTotalParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemTotalSwapParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemLimitsParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemLimitsSwapParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemCountLimHitParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class MemSwapLimitHitParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class IOParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
    class NetParser : public MetricParser{
    public:
        void parse(const std::string &data,
                   std::map<constants::Metrics,unsigned>  & metrics ) override {
        }
    };
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using data_viewer.Model.Notification;

namespace data_viewer.Constants
{
    public static class EnumMetricGroups
    {
        public static readonly IList<Metrics> CpuMetricsList = new ReadOnlyCollection<Metrics>
        (new List<Metrics>
        {
            Metrics.U_SPACE_PR,
            Metrics.K_SPACE_PR,
            Metrics.U_SPACE_MS,
            Metrics.K_SPACE_MS,
            Metrics.THROTTLE_NS,
            Metrics.THROTTLE_CNT,
            Metrics.TOTAL_NS,
            Metrics.TOTAL_PR,
        });
        public static readonly IList<Metrics> MemoryMetricsList = new ReadOnlyCollection<Metrics>
        (new List<Metrics>
        {
            Metrics.MEM_USED,
            Metrics.MEM_SWAP_USED,
            Metrics.RSS,
            Metrics.CACHE_C,
            Metrics.SWAP,
            Metrics.MEM_LIMIT,
            Metrics.MEM_SWAP_LIMIT,
            Metrics.MEM_HIT_CNT,
            Metrics.MEM_SWAP_HIT_CNT,
        });
        public static readonly IList<Metrics> IoMetricsList = new ReadOnlyCollection<Metrics>
        (new List<Metrics>
        {
            Metrics.READ,
            Metrics.WRITE,
        });
        public static readonly IList<Metrics> NetMetricsList = new ReadOnlyCollection<Metrics>
        (new List<Metrics>
        {
            Metrics.RECEIVE,
            Metrics.RECEIVE_ERROR,
            Metrics.RECEIVE_ERROR_TOTAL,
            Metrics.TRANSMIT,
            Metrics.TRANSMIT_ERROR,
            Metrics.TRANSMIT_ERROR_TOTAL
        });
    }
}
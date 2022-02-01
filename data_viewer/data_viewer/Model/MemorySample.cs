using System;

namespace data_viewer.Model
{
    public class MemorySample
    {
        public long memoryUsed { get; set; }
        public long memoryAndSwapUsed { get; set; }
        public long rss { get; set; }
        public long cache { get; set; }
        public long swap { get; set; }
        public long memoryLimit { get; set; }
        public long memoryAndSwapLimit { get; set; }
        public long memoryLimitHitCount { get; set; }
        public long memoryAndSwapLimitHitCount { get; set; }
        public DateTime dateTime { get; set; }
    }
}
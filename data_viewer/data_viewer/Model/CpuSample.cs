using System;

namespace data_viewer.Model
{
    public class CpuSample
    {
        public long userSpacePercents { get; set; }
        public long kernelSpacePercents { get; set; }
        public long userSpaceMs { get; set; }
        public long kernelSpaceMs { get; set; }
        public long throttleMs { get; set; }
        public long throttleCount { get; set; }
        public long totalMs { get; set; }
        public long totalPercents { get; set; }
        public DateTime dateTime { get; set; }
    }
}
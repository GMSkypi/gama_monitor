using System.Collections.Generic;

namespace data_viewer.Model
{
    public class CpuRecord
    {
        public IList<CpuSample> values { get; set; }
        public Container Container { get; set; }
    }
}
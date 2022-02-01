using System.Collections.Generic;

namespace data_viewer.Model
{
    public class MemoryRecord
    {
        public IList<MemorySample> values { get; set; }
        public Container Container { get; set; }
    }
}
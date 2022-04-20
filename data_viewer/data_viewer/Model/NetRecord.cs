using System.Collections.Generic;

namespace data_viewer.Model
{
    public class NetRecord
    {
        public IList<NetSample> values { get; set; }
        public Container Container { get; set; }
    }
}
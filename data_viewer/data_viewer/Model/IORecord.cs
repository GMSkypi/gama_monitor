using System.Collections.Generic;

namespace data_viewer.Model
{
    public class IORecord
    {
        public IList<IOSample> values { get; set; }
        public Container Container { get; set; }
    }
}
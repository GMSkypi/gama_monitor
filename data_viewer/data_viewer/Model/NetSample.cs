using System;

namespace data_viewer.Model
{
    public class NetSample
    {
        public long receive { get; set; }
        public long receiveErrorCountPeriod { get; set; }
        public long receiveErrorCountTotal { get; set; }
        public long transmit { get; set; }
        public long transmitErrorCountPeriod { get; set; }
        public long transmitErrorCountTotal { get; set; }
        public DateTime dateTime { get; set; }
    }
}
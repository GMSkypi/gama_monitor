using System;

namespace data_viewer.Model
{
    public class Container
    {
        public string id { get; set; }
        public string dockerID { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public DateTime lastRecord { get; set; }
    }
}
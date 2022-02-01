using System;

namespace data_viewer.Model
{
    public class Container
    {
        public String id { get; set; }
        public String dockerID { get; set; }
        public String name { get; set; }
        public string image { get; set; }
        public DateTime lastRecord { get; set; }
    }
}
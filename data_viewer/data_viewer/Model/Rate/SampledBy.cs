using System;

namespace data_viewer.Model.Rate
{
    public class SampledBy
    {
        public SampledBy(int value, String unit)
        {
            this.unit = unit;
            this.value = value;
        }
        public int value { get; set; }
        public String unit { get; set; }
        
        public String toString() {
            return  value + unit;
        }
    }
}
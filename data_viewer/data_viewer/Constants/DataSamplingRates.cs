using data_viewer.Model.Rate;

namespace data_viewer.Constants
{
    public static class DataSamplingRates
    {
        public static SampledBy minute = new SampledBy(10,"s");
        public static SampledBy hour = new SampledBy(1,"m");
        public static SampledBy day = new SampledBy(30,"m");
        public static SampledBy week = new SampledBy(6,"h");
        public static SampledBy month = new SampledBy(12,"h");
        public static SampledBy year = new SampledBy(10,"d");
        public static SampledBy inf = new SampledBy(15,"d");
    }
}
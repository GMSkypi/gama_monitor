using data_viewer.Model.Rate;

namespace data_viewer.Constants
{
    public static class DataSamplingRates
    {
        public static readonly SampledBy Minute = new SampledBy(10,"s");
        public static readonly SampledBy Hour = new SampledBy(1,"m");
        public static readonly SampledBy Day = new SampledBy(30,"m");
        public static readonly SampledBy Week = new SampledBy(6,"h");
        public static readonly SampledBy Month = new SampledBy(12,"h");
        public static readonly SampledBy Year = new SampledBy(10,"d");
        public static readonly SampledBy Inf = new SampledBy(15,"d");
    }
}
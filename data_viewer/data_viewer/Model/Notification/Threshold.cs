using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace data_viewer.Model.Notification
{
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum Threshold
    {
        AVERAGE,
        MIN,
        MAX,
        MEDIAN

    }
}
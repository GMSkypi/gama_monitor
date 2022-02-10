using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace data_viewer.Model.Notification
{
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum Threshold
    {
        [Display(Name = "Average")]
        AVERAGE,
        [Display(Name = "Minimum")]
        MIN,
        [Display(Name = "Maximum")]
        MAX,
        [Display(Name = "Median")]
        MEDIAN

    }
}
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace data_viewer.Model.Notification
{
    [JsonConverter(typeof(StringEnumConverter))]  
    public enum Group
    {
        [Display(Name = "Cpu")]
        CPU,
        [Display(Name = "Io")]
        IO,
        [Display(Name = "Memory")]
        MEMORY,
        [Display(Name = "Net")]
        NET
    }
}
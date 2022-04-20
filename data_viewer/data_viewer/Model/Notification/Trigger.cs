using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace data_viewer.Model.Notification
{
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum Trigger
    {
        [Display(Name = "Above")]
        ABOVE,
        [Display(Name = "Below")]
        BELOW
    }
}
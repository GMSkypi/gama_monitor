using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace data_viewer.Model.Notification
{
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum NotificationType
    {
        [Display(Name = "Threshold")]
        THRESHOLD,
        [Display(Name = "Change")]
        CHANGE
    }
}
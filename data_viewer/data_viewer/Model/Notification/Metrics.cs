using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace data_viewer.Model.Notification
{
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum Metrics
    {
        [Display(Name = "User space %")]
        U_SPACE_PR,
        [Display(Name = "Kernel space %")]
        K_SPACE_PR,
        [Display(Name = "User space ms")]
        U_SPACE_MS,
        [Display(Name = "Kernel space ms")]
        K_SPACE_MS,
        [Display(Name = "Throttle in ms")]
        THROTTLE_NS,
        [Display(Name = "Throttle total count")]
        THROTTLE_CNT,
        [Display(Name = "Total cpu ms")]
        TOTAL_NS,
        [Display(Name = "Total cpu %")]
        TOTAL_PR,

        [Display(Name = "IO Read")]
        READ,
        [Display(Name = "IO write")]
        WRITE,

        [Display(Name = "Memory used")]
        MEM_USED,
        [Display(Name = "Memory + swap used")]
        MEM_SWAP_USED,
        [Display(Name = "RSS")]
        RSS,
        [Display(Name = "Cache")]
        CACHE_C,
        [Display(Name = "Swap")]
        SWAP,
        [Display(Name = "Memory limit")]
        MEM_LIMIT,
        [Display(Name = "Memory + swap limit")]
        MEM_SWAP_LIMIT,
        [Display(Name = "Memory limit hit count")]
        MEM_HIT_CNT,
        [Display(Name = "Memory + swap limit hit count")]
        MEM_SWAP_HIT_CNT,

        [Display(Name = "Receive bytes")]
        RECEIVE,
        [Display(Name = "Receive errors")]
        RECEIVE_ERROR,
        [Display(Name = "Receive errors since start")]
        RECEIVE_ERROR_TOTAL,
        [Display(Name = "Transmit bytes")]
        TRANSMIT,
        [Display(Name = "Transmit errors")]
        TRANSMIT_ERROR,
        [Display(Name = "Transmit errors since start")]
        TRANSMIT_ERROR_TOTAL
    }
}
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.LockedPeriod
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("LockedPeriod")]
    public class LockedPeriod
    {
        public string EndDate { get; set; }
    }
}
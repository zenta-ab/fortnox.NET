using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Unit
{
    [JsonPropertyClass("Units")]
    public class Unit
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
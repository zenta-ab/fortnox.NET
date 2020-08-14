using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.PredefinedAccounts
{
    [JsonPropertyClass("PreDefinedAccounts")]
    public class PredefinedAccounts
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }
        
        public int Account { get; set; }
        
        public string Name { get; set; }
    }
}
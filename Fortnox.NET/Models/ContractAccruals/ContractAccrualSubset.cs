using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.ContractAccruals
{
    [JsonPropertyClass("ContractAccruals")]
    public class ContractAccrualSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        public string Description { get; set; }
        
        public int DocumentNumber { get; set; }
        
        [JsonReadOnly]
        public ContractAccrualPeriod? Period { get; set; }
    }
}
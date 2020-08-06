using FortnoxNET.Utils;
using Newtonsoft.Json;
namespace FortnoxNET.Models.CostCenter
{
    [JsonPropertyClass("CostCenters")]
    public class CostCenterSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }
        
        public bool Active { get; set; }
    }
}

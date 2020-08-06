using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.ModesOfPayments
{
    [JsonPropertyClass("ModesOfPayments")]
    public class ModesOfPaymentsSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string AccountNumber { get; set; }
    }
}

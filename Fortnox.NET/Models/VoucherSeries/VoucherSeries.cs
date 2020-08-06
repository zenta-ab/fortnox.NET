using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.VoucherSeries
{
    [JsonPropertyClass("VoucherSeries")]
    public class VoucherSeries
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool Manual { get; set; }

        [JsonReadOnly]
        public int? NextVoucherNumber { get; set; }

        [JsonReadOnly]
        public int? Year { get; set; }
    }
}

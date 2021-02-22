using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace Fortnox.NET.Models.Assets
{
    [JsonPropertyClass("Assets")]
    public class AssetsDepreciation
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public int VoucherNumber { get; set; }

        public string VoucherSeries { get; set; }

        public int FinancialYear { get; set; }
    }
}

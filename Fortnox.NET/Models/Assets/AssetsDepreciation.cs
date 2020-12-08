using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace Fortnox.NET.Models.Assets
{
    [JsonPropertyClass("Assets")]
    public class AssetsDepreciation
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Reference to voucher number
        /// </summary>
        public int VoucherNumber { get; set; }

        /// <summary>
        /// Reference to voucher series	
        /// </summary>
        public string VoucherSeries { get; set; }

        /// <summary>
        /// Financial year
        /// </summary>
        public int FinancialYear { get; set; }
    }
}

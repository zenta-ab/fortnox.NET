using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Price
{
    [JsonPropertyClass("Prices")]
    public class PriceSubset
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// The article number
        /// </summary>
        public string ArticleNumber { get; set; }

        /// <summary>
        /// The quantity from where the price is applicable
        /// </summary>
        public decimal FromQuantity { get; set; }

        /// <summary>
        /// Price list of the price
        /// </summary>
        public string PriceList { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        public decimal? Price { get; set; }
    }
}

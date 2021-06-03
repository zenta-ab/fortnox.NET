using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.PriceList
{
    [JsonPropertyClass("PriceLists")]
    public class PriceListSubset
    {
        /// <summary>
        /// Direct url to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Code of pricelist
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description of pricelist
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Comments for pricelist
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// If the price list is pre selected
        /// </summary>
        public bool? PreSelected { get; set; }
    }
}

using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.Price
{
    [JsonPropertyClass("Price")]
    public class Price
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
        /// Date of the last modification 
        /// </summary>
        [JsonReadOnly]
        public DateTime? Date { get; set; }

        /// <summary>
        /// The quantity from where the price is applicable
        /// </summary>
        public decimal? FromQuantity { get; set; }

        /// <summary>
        /// Percent of original price
        /// </summary>
        public decimal? Percent { get; set; }

        /// <summary>
        /// Price list of the price
        /// </summary>
        public string PriceList { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        [JsonProperty(PropertyName = "Price")]
        public decimal? PriceValue { get; set; }
    }
}

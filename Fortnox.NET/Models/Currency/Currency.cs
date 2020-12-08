using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.Currency
{
    [JsonPropertyClass("Currency")]
    [JsonConverter(typeof(CustomJsonConverter))]
    public class Currency
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// The buy rate of the currency
        /// </summary>
        public decimal? BuyRate { get; set; }

        /// <summary>
        /// The code of the currency
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The date of retrieval of the buy/sell rates
        /// </summary>
        [JsonReadOnly]
        public DateTime? Date { get; set; }

        /// <summary>
        /// The description of the currency
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The sell rate of the currency
        /// </summary>
        public decimal? SellRate { get; set; }

        /// <summary>
        /// The unit of the currency
        /// </summary>
        public decimal? Unit { get; set; }

        /// <summary>
        /// If the currency has automatic updates on it
        /// </summary>
        [JsonReadOnly]
        public bool? IsAutomatic { get; set; }
    }
}

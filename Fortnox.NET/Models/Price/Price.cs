using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.Price
{
    [JsonPropertyClass("Price")]
    public class Price
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string ArticleNumber { get; set; }

        [JsonReadOnly]
        public DateTime? Date { get; set; }

        public decimal FromQuantity { get; set; }

        public decimal Percent { get; set; }

        public string PriceList { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public decimal PriceValue { get; set; }
    }
}

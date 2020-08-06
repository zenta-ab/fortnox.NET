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

        public float FromQuantity { get; set; }

        public float Percent { get; set; }

        public string PriceList { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public float PriceValue { get; set; }
    }
}

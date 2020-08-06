using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;

namespace FortnoxNET.Models.Currency
{
    [JsonPropertyClass("Currency")]
    [JsonConverter(typeof(CustomJsonConverter))]
    public class Currency
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public int BuyRate { get; set; }

        public string Code { get; set; }

        [JsonReadOnly]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int SellRate { get; set; }

        public int Unit { get; set; }

        [JsonReadOnly]
        public bool IsAutomatic { get; set; }
    }
}

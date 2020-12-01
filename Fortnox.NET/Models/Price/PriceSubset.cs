using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Models.Price
{
    [JsonPropertyClass("Prices")]
    public class PriceSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string ArticleNumber { get; set; }

        public decimal FromQuantity { get; set; }

        public string PriceList { get; set; }

        public decimal Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Expense
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Expense")]
    public class Expense
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public int Account { get; set; }

    }
}

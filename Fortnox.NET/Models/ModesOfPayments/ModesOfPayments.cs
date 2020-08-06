using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxNET.Models.ModesOfPayments
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("ModesOfPayment")]
    public class ModesOfPayment
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string AccountNumber { get; set; }
   
    }
}

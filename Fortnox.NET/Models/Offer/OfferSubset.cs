using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Models.Offer
{
    [JsonPropertyClass("Offers")]
    public class OfferSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public bool Cancelled { get; set; }
        public string Currency { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string DocumentNumber { get; set; }
        public string OfferDate { get; set; }
        public int Project { get; set; }
        public bool Sent { get; set; }
        public int Total { get; set; }
    }
}

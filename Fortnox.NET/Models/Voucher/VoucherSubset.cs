using System;
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Vouchers
{
    [JsonPropertyClass("Vouchers")]
    public class VoucherSubset
    {
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }
        public string ReferenceNumber { get; set; }
        public string ReferenceType { get; set; }
        public int VoucherNumber { get; set; }
        public string VoucherSeries { get; set; }
        public int Year { get; set; }
    }
}
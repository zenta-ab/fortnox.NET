
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Order
{
    [JsonPropertyClass("Orders")]
    public class OrderSubset
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public bool Cancelled { get; set; }

        public string Currency { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public string DeliveryDate { get; set; }

        public string DocumentNumber { get; set; }

        public string ExternalInvoiceReference1 { get; set; }

        public string ExternalInvoiceReference2 { get; set; }

        public string OrderDate { get; set; }

        public string OrderType { get; set; }

        public string Project { get; set; }

        public bool Sent { get; set; }

        public int Total { get; set; }
    }
}

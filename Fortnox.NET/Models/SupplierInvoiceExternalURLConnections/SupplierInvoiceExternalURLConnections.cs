using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.SupplierInvoiceExternalURLConnection
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("SupplierInvoiceExternalURLConnection")]
    public class SupplierInvoiceExternalURLConnection
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }
        [JsonReadOnly]
        public int Id { get; set; }
        public int SupplierInvoiceNumber { get; set; }
        public string ExternalURLConnection { get; set; }
        public string Domain { get; set; }
    }
}
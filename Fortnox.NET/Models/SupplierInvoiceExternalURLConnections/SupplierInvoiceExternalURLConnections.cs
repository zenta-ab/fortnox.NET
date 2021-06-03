using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.SupplierInvoiceExternalURLConnection
{
    [JsonPropertyClass("SupplierInvoiceExternalURLConnection")]
    public class SupplierInvoiceExternalURLConnection
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Id of the connection
        /// </summary>
        [JsonReadOnly]
        public int? Id { get; set; }

        /// <summary>
        /// Supplier invoice number
        /// </summary>
        public int? SupplierInvoiceNumber { get; set; }

        /// <summary>
        /// URL of the connection
        /// </summary>
        public string ExternalURLConnection { get; set; }
    }
}
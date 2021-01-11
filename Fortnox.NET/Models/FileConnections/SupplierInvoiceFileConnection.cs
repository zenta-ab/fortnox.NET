using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.FileConnections
{
    [JsonPropertyClass("SupplierInvoiceFileConnection")]
    public class SupplierInvoiceFileConnection
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        /// <summary>
        /// Id of the file.
        /// </summary>
        public string FileId { get; set; }
        
        /// <summary>
        /// Name of the file.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Supplier invoice number.
        /// </summary>
        public string SupplierInvoiceNumber { get; set; }
        
        /// <summary>
        /// Name of the supplier.
        /// </summary>
        public string SupplierName { get; set; }
    }
}
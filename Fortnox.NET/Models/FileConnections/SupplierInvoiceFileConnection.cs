using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.FileConnections
{
    [JsonPropertyClass("SupplierInvoiceFileConnection")]
    public class SupplierInvoiceFileConnection
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        public string FileId { get; set; }
        
        public string Name { get; set; }
        
        public string SupplierInvoiceNumber { get; set; }
        
        public string SupplierName { get; set; }
    }
}
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.TaxReduction
{
    [JsonPropertyClass("TaxReductions")]
    public class TaxReduction
    {
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public decimal AskedAmount { get; set; }
        public decimal BilledAmount { get; set; }
        public string CustomerName { get; set; }
        public string Id { get; set; }
        public string PropertyDesignation { get; set; }
        public string ReferenceDocumentType { get; set; }
        public int ReferenceNumber { get; set; }
        public bool RequestSent { get; set; }
        public string ResidenceAssociationOrganisationNumber { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string TypeOfReduction { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherSeries { get; set; }
        public string VoucherYear { get; set; }
    }
}
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.TaxReduction
{
    [JsonPropertyClass("TaxReductions")]
    public class TaxReduction
    {
        /// <summary>
        /// Direct URL to the record 
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Apporoved amount
        /// </summary>
        public decimal? ApprovedAmount { get; set; }

        /// <summary>
        /// Asked amount
        /// </summary>
        public decimal? AskedAmount { get; set; }
        
        /// <summary>
        /// Billed amount
        /// </summary>
        public decimal? BilledAmount { get; set; }
        
        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName { get; set; }
        
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Property designation
        /// </summary>
        public string PropertyDesignation { get; set; }

        /// <summary>
        /// Document type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ReferenceDocumentType? ReferenceDocumentType { get; set; }

        /// <summary>
        /// Reference number
        /// </summary>
        public long? ReferenceNumber { get; set; }

        /// <summary>
        /// Is request sent
        /// </summary>
        public bool? RequestSent { get; set; }

        /// <summary>
        /// Residence association organisation number
        /// </summary>
        public string ResidenceAssociationOrganisationNumber { get; set; }

        /// <summary>
        /// Social security number
        /// </summary>
        public string SocialSecurityNumber { get; set; }
        
        /// <summary>
        /// Voucher number
        /// </summary>
        public string VoucherNumber { get; set; }

        /// <summary>
        /// Voucher series
        /// </summary>
        public string VoucherSeries { get; set; }

        /// <summary>
        /// Voucher year
        /// </summary>
        public string VoucherYear { get; set; }
    }
}
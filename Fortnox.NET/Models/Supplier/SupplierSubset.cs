using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Supplier
{ 
    [JsonPropertyClass("Suppliers")]
    public class SupplierSubset
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// First address field
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Second address field
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Bank account number of the supplier
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// BG number for the supplier
        /// </summary>
        public string BG { get; set; }

        /// <summary>
        /// Bank Identifier Code 
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// City of the supplier address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Cost center code
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Country code of the supplier address
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Currency of the supplier
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Payment file disabled for the supplier
        /// </summary>
        public bool? DisablePaymentFile { get; set; }

        /// <summary>
        /// Email of the supplier
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// International Bank Account Number
        /// </summary>
        public string IBAN { get; set; }

        /// <summary>
        /// PG number for the supplier
        /// </summary>
        public string PG { get; set; }

        /// <summary>
        /// Name of the supplier
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organisation number of the supplier
        /// </summary>
        public string OrganisationNumber { get; set; }

        /// <summary>
        /// Phone number for the supplier
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Pre defined account of the supplier
        /// </summary>
        public string PreDefinedAccount { get; set; }

        /// <summary>
        /// Project number 
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// The supplier number.
        /// </summary>
        public string SupplierNumber { get; set; }

        /// <summary>
        /// The suppliers terms of payment
        /// </summary>
        public string TermsOfPayment { get; set; }

        /// <summary>
        ///  The zip code of the supplier address
        /// </summary>
        public string ZipCode { get; set; }
    }
}

using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Supplier
{
    [JsonPropertyClass("Supplier")]
    public class Supplier
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// If active
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// First address field
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Second address field
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        ///  Bank of the supplier
        /// </summary>
        public string Bank { get; set; }

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
        /// Branch Code(SNI)
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// City of the supplier address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Clearing number
        /// </summary>
        public int? ClearingNumber { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Cost center code
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Country of the supplier address
        /// </summary>
        public string Country { get; set; }

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
        /// Fax number
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// International Bank Account Number
        /// </summary>
        public string IBAN { get; set; }

        /// <summary>
        /// Name of the supplier
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organisation number of the supplier
        /// </summary>
        public string OrganisationNumber { get; set; }

        /// <summary>
        /// Our reference for the supplier
        /// </summary>
        public string OurReference { get; set; }

        /// <summary>
        /// Our customer number for the supplier
        /// </summary>
        public string OurCustomerNumber { get; set; }

        /// <summary>
        /// PG number for the supplier
        /// </summary>
        public string PG { get; set; }

        /// <summary>
        /// Phone number for the supplier
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone number for the supplier
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Pre defined account of the supplier
        /// </summary>
        public string PreDefinedAccount { get; set; }

        /// <summary>
        ///  Project number 
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
        /// VAT Number
        /// </summary>
        public string VATNumber { get; set; }

        /// <summary>
        /// VAT Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public VATType? VATType { get; set; }

        /// <summary>
        /// Visiting address
        /// </summary>
        public string VisitingAddress { get; set; }

        /// <summary>
        /// Visiting city
        /// </summary>
        public string VisitingCity { get; set; }

        /// <summary>
        /// Visiting country
        /// </summary>
        public string VisitingCountry { get; set; }

        /// <summary>
        /// Visiting country code
        /// </summary>
        public string VisitingCountryCode { get; set; }

        /// <summary>
        /// Visiting zip code
        /// </summary>
        public string VisitingZipCode { get; set; }

        /// <summary>
        /// Work place(CFAR)
        /// </summary>
        public string WorkPlace { get; set; }

        /// <summary>
        /// The suppliers website
        /// </summary>
        public string WWW { get; set; }

        /// <summary>
        /// Your reference for the supplier
        /// </summary>
        public string YourReference { get; set; }

        /// <summary>
        ///  The zip code of the supplier address
        /// </summary>
        public string ZipCode { get; set; }
    }
}

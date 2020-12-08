using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.CompanySettings
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("CompanySettings")]
    public class CompanySettings
    {
        /// <summary>
        /// Direct URL to the record
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Address for the company
        /// </summary>
        [JsonReadOnly]
        public string Address { get; set; }

        /// <summary>
        /// Bankgiro
        /// </summary>
        [JsonReadOnly]
        public string BG { get; set; }

        /// <summary>
        /// BIC
        /// </summary>
        [JsonReadOnly]
        public string BIC { get; set; }

        /// <summary>
        /// Branch code (SNI)
        /// </summary>
        [JsonReadOnly]
        public string BranchCode { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonReadOnly]
        public string City { get; set; }

        /// <summary>
        /// Contact person – First name
        /// </summary>
        [JsonReadOnly]
        public string ContactFirstName { get; set; }

        /// <summary>
        /// Contact person – Last name
        /// </summary>
        [JsonReadOnly]
        public string ContactLastName { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [JsonReadOnly]
        public string Country { get; set; }

        /// <summary>
        /// CountryCode
        /// </summary>
        [JsonReadOnly]
        public string CountryCode { get; set; }

        /// <summary>
        /// 	Database number
        /// </summary>
        [JsonReadOnly]
        public string DatabaseNumber { get; set; }

        /// <summary>
        /// Domicile
        /// </summary>
        [JsonReadOnly]
        public string Domicile { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonReadOnly]
        public string Email { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        [JsonReadOnly]
        public string Fax { get; set; }

        /// <summary>
        /// IBAN
        /// </summary>
        [JsonReadOnly]
        public string IBAN { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        [JsonReadOnly]
        public string Name { get; set; }

        /// <summary>
        /// Organisation number
        /// </summary>
        [JsonReadOnly]
        public string OrganizationNumber { get; set; }

        /// <summary>
        /// Plusgiro
        /// </summary>
        [JsonReadOnly]
        public string PG { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [JsonReadOnly]
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [JsonReadOnly]
        public string Phone2 { get; set; }

        /// <summary>
        /// Tax enabled
        /// </summary>
        [JsonReadOnly]
        public bool TaxEnabled { get; set; }

        /// <summary>
        /// VAT number
        /// </summary>
        [JsonReadOnly]
        public string VatNumber { get; set; }

        /// <summary>
        /// Visit address
        /// </summary>
        [JsonReadOnly]
        public string VisitAddress { get; set; }

        /// <summary>
        /// Visit city
        /// </summary>
        [JsonReadOnly]
        public string VisitCity { get; set; }

        /// <summary>
        /// Visit country
        /// </summary>
        [JsonReadOnly]
        public string VisitCountry { get; set; }

        /// <summary>
        /// Visit country code
        /// </summary>
        [JsonReadOnly]
        public string VisitCountryCode { get; set; }

        /// <summary>
        /// Visit name
        /// </summary>
        [JsonReadOnly]
        public string VisitName { get; set; }

        /// <summary>
        /// Visit zip code
        /// </summary>
        [JsonReadOnly]
        public string VisitZipCode { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        [JsonReadOnly]
        public string WWW { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        [JsonReadOnly]
        public string ZipCode { get; set; }
    }
}
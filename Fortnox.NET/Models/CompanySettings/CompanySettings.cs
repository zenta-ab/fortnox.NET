using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.CompanySettings
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("CompanySettings")]
    public class CompanySettings
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        
        [JsonReadOnly]
        public string Address { get; set; }
        
        [JsonReadOnly]
        public string BG { get; set; }
        
        [JsonReadOnly]
        public string BIC { get; set; }
        
        [JsonReadOnly]
        public string BranchCode { get; set; }
        
        [JsonReadOnly]
        public string City { get; set; }
        
        [JsonReadOnly]
        public string ContactFirstName { get; set; }
        
        [JsonReadOnly]
        public string ContactLastName { get; set; }
        
        [JsonReadOnly]
        public string Country { get; set; }
        
        [JsonReadOnly]
        public string CountryCode { get; set; }
        
        [JsonReadOnly]
        public string DatabaseNumber { get; set; }
        
        [JsonReadOnly]
        public string Domicile { get; set; }
        
        [JsonReadOnly]
        public string Email { get; set; }
        
        [JsonReadOnly]
        public string Fax { get; set; }
        
        [JsonReadOnly]
        public string IBAN { get; set; }
        
        [JsonReadOnly]
        public string Name { get; set; }
        
        [JsonReadOnly]
        public string OrganizationNumber { get; set; }
        
        [JsonReadOnly]
        public string PG { get; set; }
        
        [JsonReadOnly]
        public string Phone1 { get; set; }
        
        [JsonReadOnly]
        public string Phone2 { get; set; }
        
        [JsonReadOnly]
        public bool TaxEnabled { get; set; }
        
        [JsonReadOnly]
        public string VatNumber { get; set; }
        
        [JsonReadOnly]
        public string VisitingCountry { get; set; }
        
        [JsonReadOnly]
        public string VisitingCountryCode { get; set; }
        
        [JsonReadOnly]
        public string VisitName { get; set; }
        
        [JsonReadOnly]
        public string VisitZipCode { get; set; }
        
        [JsonReadOnly]
        public string WWW { get; set; }
        
        [JsonReadOnly]
        public string ZipCode { get; set; }
    }
}
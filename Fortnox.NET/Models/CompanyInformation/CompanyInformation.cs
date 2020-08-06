using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.CompanyInformation
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("CompanyInformation")]
    public class CompanyInformation
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string DatabaseNumber { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string VisitAddress { get; set; }
        public string VisitCity { get; set; }
        public string VisitCountryCode { get; set; }
        public string VisitZipCode { get; set; }
        public string ZipCode { get; set; }
    }
}

using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.CompanyInformation
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("CompanyInformation")]
    public class CompanyInformation
    {
        /// <summary>
        /// Address for the company
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Country Code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Database number
        /// </summary>
        public string DatabaseNumber { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Organisation number
        /// </summary>
        public string OrganizationNumber { get; set; }

        /// <summary>
        /// Visit address
        /// </summary>
        public string VisitAddress { get; set; }

        /// <summary>
        /// Visit city
        /// </summary>
        public string VisitCity { get; set; }

        /// <summary>
        /// Visit country code
        /// </summary>
        public string VisitCountryCode { get; set; }

        /// <summary>
        /// Visit zip code
        /// </summary>
        public string VisitZipCode { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode { get; set; }
    }
}

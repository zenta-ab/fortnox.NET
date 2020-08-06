using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Customer
{
    [JsonPropertyClass("Customers")]
    public class CustomerSubset
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string CustomerNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string OrganisationNumber { get; set; }
        
        /// <summary>
        /// Phone is same property as Phone1 when getting complete customer.
        /// </summary>
        public string Phone { get; set; }
        public string ZipCode { get; set; }
    }
}
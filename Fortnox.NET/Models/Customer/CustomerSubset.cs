using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Customer
{
    [JsonPropertyClass("Customers")]
    public class CustomerSubset
    {
        /// <summary>
        /// Direct URL to the record.
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Address 1 of the customer.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address 2 of the customer.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// City of the customer.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Customer number of the customer.
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Email address for the customer. 
        /// This must be a valid email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organisation number of the customer. 
        /// It needs to be a valid organisation numer.
        /// </summary>
        public string OrganisationNumber { get; set; }

        /// <summary>
        /// Phone number of the customer.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Zip code of the customers.
        /// </summary>
        public string ZipCode { get; set; }
    }
}
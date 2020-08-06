using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Supplier
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Supplier")]
    public class Supplier
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public bool Active { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Bank { get; set; }

        public int? BankAccountNumber { get; set; }

        public string BG { get; set; }

        public string BIC { get; set; }

        public string BranchCode { get; set; }

        public string City { get; set; }

        public int? ClearingNumber { get; set; }

        public string Comments { get; set; }

        public string CostCenter { get; set; }

        public string Country { get; set; }

        public string CountryCode { get; set; }

        public string Currency { get; set; }

        public bool DisablePaymentFile { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string IBAN { get; set; }

        public string Name { get; set; }

        public string OrganisationNumber { get; set; }

        public string OurReference { get; set; }

        public string OurCustomerNumber { get; set; }

        public string PG { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string PreDefinedAccount { get; set; }

        public string Project { get; set; }

        public string SupplierNumber { get; set; }

        public string TermsOfPayment { get; set; }

        public string VATNumber { get; set; }

        public string VATType { get; set; }

        public string VisitingAddress { get; set; }

        public string VisitingCity { get; set; }

        public string VisitingCountry { get; set; }

        public string VisitingCountryCode { get; set; }

        public string VisitingZipCode { get; set; }

        public string WorkPlace { get; set; }

        public string WWW { get; set; }

        public string YourReference { get; set; }

        public string ZipCode { get; set; }
    }
}

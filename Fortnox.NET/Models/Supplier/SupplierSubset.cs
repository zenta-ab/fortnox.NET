using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Supplier
{ 
    [JsonPropertyClass("Suppliers")]
    public class SupplierSubset
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public int BankAccountNumber { get; set; }

        public string BG { get; set; }

        public string BIC { get; set; }

        public string City { get; set; }

        public string CostCenter { get; set; }

        public string CountryCode { get; set; }

        public string Currency { get; set; }

        public bool DisablePaymentFile { get; set; }

        public string Email { get; set; }

        public string IBAN { get; set; }

        public string PG { get; set; }

        public string Name { get; set; }

        public string OrganisationNumber { get; set; }

        public string Phone { get; set; }

        public string PreDefinedAccount { get; set; }

        public string Project { get; set; }

        public string SupplierNumber { get; set; }

        public string TermsOfPayment { get; set; }

        public string ZipCode { get; set; }
    }
}

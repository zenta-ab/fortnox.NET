using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Customer
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Customer")]
    public class Customer
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [JsonReadOnly]
        public string Country { get; set; }
        public string CustomerNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string OrganisationNumber { get; set; }
        public string ZipCode { get; set; }
        public bool? Active { get; set; }
        public string Comments { get; set; }
        public string CostCenter { get; set; }
        public string Currency { get; set; }
        public DefaultDeliveryTypes DefaultDeliveryTypes { get; set; }
        public DefaultTemplates DefaultTemplates { get; set; }
        public string DeliveryAddress1 { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string DeliveryCity { get; set; }
        [JsonReadOnly]
        public string DeliveryCountry { get; set; }
        public string DeliveryCountryCode { get; set; }
        public string DeliveryFax { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryPhone1 { get; set; }
        public string DeliveryPhone2 { get; set; }
        public string DeliveryZipCode { get; set; }
        public string EmailInvoice { get; set; }
        public string EmailInvoiceBCC { get; set; }
        public string EmailInvoiceCC { get; set; }
        public string EmailOffer { get; set; }
        public string EmailOfferBCC { get; set; }
        public string EmailOfferCC { get; set; }
        public string EmailOrder { get; set; }
        public string EmailOrderBCC { get; set; }
        public string EmailOrderCC { get; set; }
        public string Fax { get; set; }
        public string GLN { get; set; }
        public string GLNDelivery { get; set; }
        public decimal? InvoiceAdministrationFee { get; set; }
        public decimal? InvoiceDiscount { get; set; }
        public decimal? InvoiceFreight { get; set; }
        public string InvoiceRemark { get; set; }
        public string OurReference { get; set; }
        
        /// <summary>
        /// Phone1 is same property as Phone when getting a list of subset customers.
        /// </summary>
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string PriceList { get; set; }
        public string Project { get; set; }
        public string SalesAccount { get; set; }
        public bool? ShowPriceVATIncluded { get; set; }
        public string TermsOfDelivery { get; set; }
        public string TermsOfPayment { get; set; }
        public CustomerType Type { get; set; }
        public string VATNumber { get; set; }
        public VatType? VATType { get; set; }
        public string VisitingAddress { get; set; }
        public string VisitingCity { get; set; }
        
        [JsonReadOnly]
        public string VisitingCountry { get; set; }
        public string VisitingCountryCode { get; set; }
        public string VisitingZipCode { get; set; }
        public string WWW { get; set; }
        public string WayOfDelivery { get; set; }
        public string YourReference { get; set; }
    }
}
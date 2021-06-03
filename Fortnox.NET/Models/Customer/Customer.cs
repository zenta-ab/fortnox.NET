using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Customer
{
    [JsonPropertyClass("Customer")]
    public class Customer
    {
        /// <summary>
        /// Direct URL to the record.
        /// </summary>
        [JsonReadOnly]
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
        /// Country name for the customer.
        /// </summary>
        [JsonReadOnly]
        public string Country { get; set; }

        /// <summary>
        /// Customer number of the customer.
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Email address for the customer. This must be a valid email address.
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
        /// Zip code of the customers.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// If the customer is active or not
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// Comments of the customer.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Code of the cost center for the customer. The code must be of a an existing currency.
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Code of the currency for the customer. 
        /// This will be used as the predefined currency for documents for the customer. 
        /// The code must be of an existing currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Code of the country for the customer. 
        /// The code must be of an existing country according to ISO 3166-1 Alpha-2.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Default delivery types
        /// </summary>
        public DefaultDeliveryTypes DefaultDeliveryTypes { get; set; }

        /// <summary>
        /// Default templates
        /// </summary>
        public DefaultTemplates DefaultTemplates { get; set; }

        /// <summary>
        /// Delivery address 1 for the customer.
        /// </summary>
        public string DeliveryAddress1 { get; set; }

        /// <summary>
        /// DeliveryAddress 2 for the customer.
        /// </summary>
        public string DeliveryAddress2 { get; set; }

        /// <summary>
        /// Delivery city for the customer.
        /// </summary>
        public string DeliveryCity { get; set; }

        /// <summary>
        /// Delivery country for the customer.
        /// </summary>
        [JsonReadOnly]
        public string DeliveryCountry { get; set; }

        /// <summary>
        /// Code of the delivery country for the customer. 
        /// The code must be of an existing country according to ISO 3166-1 Alpha-2.
        /// </summary>
        public string DeliveryCountryCode { get; set; }

        /// <summary>
        /// Delivery fax number of the customer.
        /// </summary>
        public string DeliveryFax { get; set; }

        /// <summary>
        /// Delivery name for the customer.
        /// </summary>
        public string DeliveryName { get; set; }

        /// <summary>
        /// Delivery phone number 1 for the customer.
        /// </summary>
        public string DeliveryPhone1 { get; set; }

        /// <summary>
        /// Delivery phone number 2 for the customer.
        /// </summary>
        public string DeliveryPhone2 { get; set; }

        /// <summary>
        /// Delivery zip code for the customer.
        /// </summary>
        public string DeliveryZipCode { get; set; }

        /// <summary>
        /// Specific email address used for invoices sent to the customer. 
        /// This must be a valid email address.
        /// </summary>
        public string EmailInvoice { get; set; }

        /// <summary>
        /// Specific blind carbon copy email address used for invoices sent to the customer.
        /// This must be a valid email address.
        /// </summary>
        public string EmailInvoiceBCC { get; set; }

        /// <summary>
        /// Specific carbon copy email address used for invoices sent to the customer.
        /// This must be a valid email address.
        /// </summary>
        public string EmailInvoiceCC { get; set; }

        /// <summary>
        /// Specific email address used for offers sent to the customer. 
        /// This must be a valid email address.
        /// </summary>
        public string EmailOffer { get; set; }

        /// <summary>
        /// Specific blind carbon copy email address used for offers sent to the customer. 
        /// This must be a valid email address.
        /// </summary>
        public string EmailOfferBCC { get; set; }

        /// <summary>
        /// Specific carbon copy email address used for offers sent to the customer.
        /// This must be a valid email address.
        /// </summary>
        public string EmailOfferCC { get; set; }

        /// <summary>
        /// Specific email address used for orders sent to the customer.
        /// This must be a valid email address.
        /// </summary>
        public string EmailOrder { get; set; }

        /// <summary>
        /// Specific blind carbon copy email address used for orders sent to the customer. 
        /// This must be a valid email address.
        /// </summary>
        public string EmailOrderBCC { get; set; }

        /// <summary>
        /// Specific carbon copy email address used for orders sent to the customer. 
        /// This must be a valid email address.
        /// </summary>
        public string EmailOrderCC { get; set; }

        /// <summary>
        /// Fax number for the customer.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Global Location Number of the customer
        /// </summary>
        public string GLN { get; set; }

        /// <summary>
        /// Global Location Delivery Number
        /// </summary>
        public string GLNDelivery { get; set; }

        /// <summary>
        /// Predefined invoice administration fee for the customer.
        /// </summary>
        public decimal? InvoiceAdministrationFee { get; set; }

        /// <summary>
        /// Predefined invoice discount for the customer.
        /// </summary>
        public decimal? InvoiceDiscount { get; set; }

        /// <summary>
        /// Predefined invoice freight fee for the customer.
        /// </summary>
        public decimal? InvoiceFreight { get; set; }

        /// <summary>
        /// Predefined invoice remark for the customer.
        /// </summary>
        public string InvoiceRemark { get; set; }

        /// <summary>
        /// Our reference of the customer.
        /// </summary>
        public string OurReference { get; set; }

        /// <summary>
        /// Phone number 1 of the customer.
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone number 2 of the customer.
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Code of the price list for the customer. 
        /// The code must be of a an existing price list.
        /// </summary>
        public string PriceList { get; set; }

        /// <summary>
        /// Number of the project for the customer. 
        /// The number must be of a an existing project.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Predefined sales account of the customer.
        /// </summary>
        public string SalesAccount { get; set; }

        /// <summary>
        /// If prices should be displayed with VAT included.
        /// </summary>
        public bool? ShowPriceVATIncluded { get; set; }

        /// <summary>
        /// Code of the terms of delivery for the customer.
        /// The code must be of a an existing terms of delivery.
        /// </summary>
        public string TermsOfDelivery { get; set; }

        /// <summary>
        /// Code of the terms of payment for the customer.
        /// The code must be of a an existing terms of payment.
        /// </summary>
        public string TermsOfPayment { get; set; }

        /// <summary>
        /// Type of the customer. 
        /// Can be PRIVATE or COMPANY.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomerType Type { get; set; }

        /// <summary>
        /// VAT number for the customer.
        /// </summary>
        public string VATNumber { get; set; }

        /// <summary>
        /// VAT type of the customer. 
        /// Can be SEVAT SEREVERSEDVAT EUREVERSEDVAT EUVAT or EXPORT.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public VATType? VATType { get; set; }

        /// <summary>
        /// Visiting address of the customer.
        /// </summary>
        public string VisitingAddress { get; set; }

        /// <summary>
        /// Visiting city of the customer.
        /// </summary>
        public string VisitingCity { get; set; }

        /// <summary>
        /// Visiting country of the customer.
        /// </summary>
        [JsonReadOnly]
        public string VisitingCountry { get; set; }

        /// <summary>
        /// Code of the visiting country for the customer. 
        /// The code must be of an existing country according to ISO 3166-1 Alpha-2.
        /// </summary>
        public string VisitingCountryCode { get; set; }

        /// <summary>
        /// Visiting zip code of the customer.
        /// </summary>
        public string VisitingZipCode { get; set; }

        /// <summary>
        /// Website of the customer.
        /// </summary>
        public string WWW { get; set; }

        /// <summary>
        /// Code of the way of delivery for the customer. 
        /// The code must be of a an existing way of delivery.
        /// </summary>
        public string WayOfDelivery { get; set; }

        /// <summary>
        /// Your reference of the customer.
        /// </summary>
        public string YourReference { get; set; }
    }
}
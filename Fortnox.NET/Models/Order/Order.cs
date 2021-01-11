using Fortnox.NET.Models.Common;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace FortnoxNET.Models.Order
{
    [JsonPropertyClass("Order")]
    public class Order
    {
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public bool ShouldSerializeUrl() => false;

        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

        public bool ShouldSerializeUrlTaxReductionList() => false;

        public decimal? AdministrationFee { get; set; }

        public decimal? AdministrationFeeVAT { get; set; }

        public bool ShouldSerializeAdministrationFeeVAT() => false;

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public decimal? BasisTaxReduction { get; set; }

        public bool ShouldSerializeBasisTaxReduction() => false;

        public bool? Cancelled { get; set; }

        public bool ShouldSerializeCancelled() => false;

        public string City { get; set; }

        public string Comments { get; set; }

        public decimal? ContributionPercent { get; set; }

        public bool ShouldSerializeContributionPercent() => false;

        public decimal? ContributionValue { get; set; }

        public bool ShouldSerializeContributionValue() => false;

        public bool? CopyRemarks { get; set; }

        public string Country { get; set; }

        public string Currency { get; set; }

        public decimal? CurrencyRate { get; set; }

        public decimal? CurrencyUnit { get; set; }

        public string CustomerName { get; set; }

        public string CustomerNumber { get; set; }

        public string DeliveryAddress1 { get; set; }

        public string DeliveryAddress2 { get; set; }

        public string DeliveryCity { get; set; }

        public string DeliveryCountry { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string DeliveryName { get; set; }

        public string DeliveryZipCode { get; set; }

        public int DocumentNumber { get; set; }

        public EmailInformation EmailInformation { get; set; }

        public string ExternalInvoiceReference1 { get; set; }

        public string ExternalInvoiceReference2 { get; set; }

        public decimal? Freight { get; set; }

        public decimal FreightVAT { get; set; }

        public bool ShouldSerializeFreightVAT() => false;

        public decimal? Gross { get; set; }

        public bool ShouldSerializeGross() => false;

        public bool? HouseWork { get; set; }

        public bool ShouldSerializeHouseWork() => false;

        public int? InvoiceReference { get; set; }

        public bool ShouldSerializeInvoiceReference() => false;

        public decimal? Net { get; set; }

        public bool ShouldSerializeNet() => false;

        public bool? NotCompleted { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? OfferReference { get; set; }

        public bool ShouldSerializeOfferReference() => false;

        public List<OrderRow> OrderRows { get; set; }

        public string OrderType { get; set; }

        public bool ShouldSerializeOrderType() => false;

        [JsonReadOnly]
        public string OrganisationNumber { get; set; }

        public bool ShouldSerializeOrganisationNumber() => false;

        public string OurReference { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string PriceList { get; set; }

        public string PrintTemplate { get; set; }

        public string Project { get; set; }

        public string Remarks { get; set; }

        public decimal? RoundOff { get; set; }

        public bool ShouldSerializeRoundOff() => false;

        public bool? Sent { get; set; }

        public bool ShouldSerializeSent() => false;

        public decimal? TaxReduction { get; set; }

        public bool ShouldSerializeTaxReduction() => false;

        /// <summary>
        /// Tax Reduction Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TaxReductionType? TaxReductionType { get; set; }

        public string TermsOfDelivery { get; set; }

        public string TermsOfPayment { get; set; }

        public decimal? Total { get; set; }

        public bool ShouldSerializeTotal() => false;

        public decimal? TotalVAT { get; set; }

        public bool ShouldSerializeTotalVAT() => false;

        public bool? VATIncluded { get; set; }

        public string WayOfDelivery { get; set; }

        public string YourReference { get; set; }

        public string YourOrderNumber { get; set; }

        public string ZipCode { get; set; }

        // NOTE(Oskar): Labels are not documented within the Order documentation on fortnox
        // but supported as you can read here: https://developer.fortnox.se/documentation/resources/labels/
        public List<OrderLabel> Labels { get; set; }

        // Warehouse Resource specific fields
        // When the Warehouse module is activated new fields are available
        // https://developer.fortnox.se/documentation/resources/warehouse-resourse-specific-fields/

        /// <summary>
        /// Document delivery state 
        /// Valid values:
        /// registration    When the document is in this state no items will be reserved or delivered.
        /// reservation     When the document is in this state items will be reserved when possible.
        /// delivery        When the document is in this state items will be delivered when possible.
        /// </summary>
        public string DeliveryState { get; set; }

        /// <summary>
        /// Used to see if the document has been marked as ready in warehouse
        /// </summary>
        public bool? WarehouseReady { get; set; }

        public bool ShouldSerializeWarehouseReady() => false;

        /// <summary>
        /// The date that the document was marked as ready in warehouse
        /// </summary>
        public DateTime? OutboundDate { get; set; }
    }
}

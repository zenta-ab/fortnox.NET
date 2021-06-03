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
        /// <summary>
        /// Direct url to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public bool ShouldSerializeUrl() => false;

        /// <summary>
        /// Direct url to the tax reduction for the order.
        /// </summary>
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }
        public bool ShouldSerializeUrlTaxReductionList() => false;

        /// <summary>
        /// Administration fee
        /// </summary>
        public decimal? AdministrationFee { get; set; }

        /// <summary>
        /// VAT of the administration fee
        /// </summary>
        public decimal? AdministrationFeeVAT { get; set; }
        public bool ShouldSerializeAdministrationFeeVAT() => false;

        /// <summary>
        /// Address 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Address 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The amount that Taxreduction is based on
        /// </summary>
        public decimal? BasisTaxReduction { get; set; }
        public bool ShouldSerializeBasisTaxReduction() => false;

        /// <summary>
        /// If Order is cancelled
        /// </summary>
        public bool? Cancelled { get; set; }
        public bool ShouldSerializeCancelled() => false;

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Contribution in Percent
        /// </summary>
        public decimal? ContributionPercent { get; set; }
        public bool ShouldSerializeContributionPercent() => false;

        /// <summary>
        /// Contribution in amount
        /// </summary>
        public decimal? ContributionValue { get; set; }
        public bool ShouldSerializeContributionValue() => false;

        /// <summary>
        /// If remarks shall be copied from order to invoice
        /// </summary>
        public bool? CopyRemarks { get; set; }

        /// <summary>
        /// Country, must be a name of an existing country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Code of the cost center
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Currency 
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Currency rate
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// Currency unit
        /// </summary>
        public decimal? CurrencyUnit { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer number
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Delivery address 1
        /// </summary>
        public string DeliveryAddress1 { get; set; }

        /// <summary>
        /// Delivery address 2
        /// </summary>
        public string DeliveryAddress2 { get; set; }

        /// <summary>
        /// Delivery City
        /// </summary>
        public string DeliveryCity { get; set; }

        /// <summary>
        /// Delivery Country 
        /// </summary>
        public string DeliveryCountry { get; set; }

        /// <summary>
        /// Delivery date
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Delivery name
        /// </summary>
        public string DeliveryName { get; set; }

        /// <summary>
        /// Delivery zip code
        /// </summary>
        public string DeliveryZipCode { get; set; }

        /// <summary>
        /// Document number
        /// </summary>
        public int DocumentNumber { get; set; }

        /// <summary>
        /// Email information
        /// </summary>
        public EmailInformation EmailInformation { get; set; }

        /// <summary>
        /// External invoice reference 1
        /// </summary>
        public string ExternalInvoiceReference1 { get; set; }

        /// <summary>
        /// External invoice reference 2
        /// </summary>
        public string ExternalInvoiceReference2 { get; set; }

        /// <summary>
        /// Freight
        /// </summary>
        public decimal? Freight { get; set; }

        /// <summary>
        /// VAT of the freight
        /// </summary>
        public decimal FreightVAT { get; set; }
        public bool ShouldSerializeFreightVAT() => false;

        /// <summary>
        /// Gross value of the order
        /// </summary>
        public decimal? Gross { get; set; }
        public bool ShouldSerializeGross() => false;

        /// <summary>
        /// If Order is marked as housework
        /// </summary>
        public bool? HouseWork { get; set; }
        public bool ShouldSerializeHouseWork() => false;

        /// <summary>
        /// Reference if an invoice is created from order
        /// </summary>
        public int? InvoiceReference { get; set; }
        public bool ShouldSerializeInvoiceReference() => false;

        /// <summary>
        /// Net amount
        /// </summary>
        public decimal? Net { get; set; }
        public bool ShouldSerializeNet() => false;

        /// <summary>
        /// If order is set to complete
        /// </summary>
        public bool? NotCompleted { get; set; }

        /// <summary>
        /// Date of order
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Reference to offer number
        /// </summary>
        public int? OfferReference { get; set; }
        public bool ShouldSerializeOfferReference() => false;

        /// <summary>
        /// Order rows
        /// </summary>
        public List<OrderRow> OrderRows { get; set; }

        /// <summary>
        /// Type of the Order. Can be Order or Backorder.
        /// </summary>
        //[JsonConverter(typeof(StringEnumConverter))]
        public string OrderType { get; set; }
        public bool ShouldSerializeOrderType() => false;

        /// <summary>
        /// Organization number
        /// </summary>
        public string OrganisationNumber { get; set; }
        public bool ShouldSerializeOrganisationNumber() => false;

        /// <summary>
        /// Our reference
        /// </summary>
        public string OurReference { get; set; }

        /// <summary>
        /// Phone 1
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone 2
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Price list code
        /// </summary>
        public string PriceList { get; set; }

        /// <summary>
        /// Print document template
        /// </summary>
        public string PrintTemplate { get; set; }

        /// <summary>
        /// Project code
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Remarks on order
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Roundof amount
        /// </summary>
        public decimal? RoundOff { get; set; }
        public bool ShouldSerializeRoundOff() => false;

        /// <summary>
        /// If document is printed or e-mailed 
        /// </summary>
        public bool? Sent { get; set; }
        public bool ShouldSerializeSent() => false;

        /// <summary>
        /// Amount of the Taxreduction
        /// </summary>
        public decimal? TaxReduction { get; set; }
        public bool ShouldSerializeTaxReduction() => false;

        /// <summary>
        /// Tax Reduction Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TaxReductionType? TaxReductionType { get; set; }

        /// <summary>
        /// Terms of delivery code
        /// </summary>
        public string TermsOfDelivery { get; set; }

        /// <summary>
        /// Terms of payment code
        /// </summary>
        public string TermsOfPayment { get; set; }

        /// <summary>
        /// Total amount
        /// </summary>
        public decimal? Total { get; set; }
        public bool ShouldSerializeTotal() => false;

        /// <summary>
        /// Total vat amount
        /// </summary>
        public decimal? TotalVAT { get; set; }
        public bool ShouldSerializeTotalVAT() => false;

        /// <summary>
        /// If order row price exclude or include vat
        /// </summary>
        public bool? VATIncluded { get; set; }

        /// <summary>
        /// Code of delivery
        /// </summary>
        public string WayOfDelivery { get; set; }

        /// <summary>
        /// Customer reference
        /// </summary>
        public string YourReference { get; set; }

        /// <summary>
        /// Customer order number
        /// </summary>
        public string YourOrderNumber { get; set; }

        /// <summary>
        /// Order zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Labels
        /// </summary>
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

        /// <summary>
        /// Stock point id
        /// </summary>
        public string StockPointId { get; set; }

        /// <summary>
        /// Stock point code
        /// </summary>
        public string StockPointCode { get; set; }
    }
}

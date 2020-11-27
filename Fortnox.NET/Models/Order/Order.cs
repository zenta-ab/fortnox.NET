using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxNET.Models.Order
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Order")]
    public class Order
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        [JsonReadOnly]
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

        public float AdministrationFee { get; set; }

        [JsonReadOnly]
        public float AdministrationFeeVAT { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [JsonReadOnly]
        public float BasisTaxReduction { get; set; }

        [JsonReadOnly]
        public bool Cancelled { get; set; }

        public string City { get; set; }

        public string Comments { get; set; }

        [JsonReadOnly]
        public float ContributionPercent { get; set; }

        [JsonReadOnly]
        public float ContributionValue { get; set; }

        public bool CopyRemarks { get; set; }

        public string Country { get; set; }

        public string Currency { get; set; }

        public float? CurrencyRate { get; set; }

        public float? CurrencyUnit { get; set; }

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

        public float Freight { get; set; }

        [JsonReadOnly]
        public float FreightVAT { get; set; }

        [JsonReadOnly]
        public float Gross { get; set; }

        [JsonReadOnly]
        public bool HouseWork { get; set; }

        [JsonReadOnly]
        public int InvoiceReference { get; set; }

        [JsonReadOnly]
        public float Net { get; set; }

        public bool NotCompleted { get; set; }

        public DateTime? OrderDate { get; set; }

        [JsonReadOnly]
        public int OfferReference { get; set; }

        public List<OrderRow> OrderRows { get; set; }

        [JsonReadOnly]
        public string OrderType { get; set; }

        [JsonReadOnly]
        public string OrganisationNumber { get; set; }

        public string OurReference { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string PriceList { get; set; }

        public string PrintTemplate { get; set; }

        public string Project { get; set; }

        public string Remarks { get; set; }

        [JsonReadOnly]
        public float RoundOff { get; set; }

        [JsonReadOnly]
        public bool Sent { get; set; }

        [JsonReadOnly]
        public float? TaxReduction { get; set; }

        public string TermsOfDelivery { get; set; }

        public string TermsOfPayment { get; set; }

        [JsonReadOnly]
        public float Total { get; set; }

        [JsonReadOnly]
        public float TotalVAT { get; set; }

        public bool VATIncluded { get; set; }

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
        [JsonReadOnly]
        public bool? WarehouseReady { get; set; }

        /// <summary>
        /// The date that the document was marked as ready in warehouse
        /// </summary>
        public DateTime? OutboundDate { get; set; }
    }
}

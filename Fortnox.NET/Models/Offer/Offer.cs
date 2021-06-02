using Fortnox.NET.Models.Common;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace FortnoxNET.Models.Offer
{
    [JsonPropertyClass("Offer")]
    public class Offer
    {
        /// <summary>
        ///  Direct url to the record
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
        public bool ShouldSerializeUrl() => false;

        /// <summary>
        /// Direct url to the tax reduction
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
        /// If the offer is cancelled
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
        /// Remarks will be copied from offer to order	
        /// </summary>
        public bool? CopyRemarks { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Cost center	
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
        /// Delivery zipcode
        /// </summary>
        public string DeliveryZipCode { get; set; }

        /// <summary>
        /// Document Number
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Email information
        /// </summary>
        public EmailInformation EmailInformation { get; set; }

        /// <summary>
        /// Expire date
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// Freight
        /// </summary>
        public decimal? Freight { get; set; }

        /// <summary>
        /// VAT of the freight
        /// </summary>
        public decimal? FreightVAT { get; set; }
        public bool ShouldSerializeFreightVAT() => false;

        /// <summary>
        /// Gross value of the offer
        /// </summary>
        public decimal? Gross { get; set; }
        public bool ShouldSerializeGross() => false;

        /// <summary>
        /// If offer is marked with housework
        /// </summary>
        public bool? HouseWork { get; set; }
        public bool ShouldSerializeHouseWork() => false;

        /// <summary>
        /// Invoice reference
        /// </summary>
        public string InvoiceReference { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Net amount
        /// </summary>
        public decimal? Net { get; set; }
        public bool ShouldSerializeNet() => false;

        /// <summary>
        /// If the offer is marked Completed
        /// </summary>
        public bool? NotCompleted { get; set; }

        /// <summary>
        /// Date of order
        /// </summary>
        public DateTime? OfferDate { get; set; }

        /// <summary>
        /// Offer rows
        /// </summary>
        public List<OfferRow> OfferRows { get; set; }

        /// <summary>
        /// Reference if an order is created from offer
        /// </summary>
        public string OrderReference { get; set; }
        public bool ShouldSerializeOrderReference() => false;

        /// <summary>
        /// Organisation number
        /// </summary>
        public string OrganisationNumber { get; set; }

        /// <summary>
        /// Our reference
        /// </summary>
        public string OurReference { get; set; }
        public bool ShouldSerializeOurReference() => false;

        /// <summary>
        /// Phone 1
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone 2
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Pricelist code
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
        /// Remarks on offer
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Round off amount
        /// </summary>
        public decimal? RoundOff { get; set; }
        public bool ShouldSerializeRoundOff() => false;

        /// <summary>
        /// If document is printed or e-mailed to customer
        /// </summary>
        public bool? Sent { get; set; }
        public bool ShouldSerializeSent() => false;

        /// <summary>
        /// Amount of Taxreduction
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
        /// Total amount to pay
        /// </summary>
        public decimal? TotalToPay { get; set; }
        public bool ShouldSerializeTotalToPay() => false;

        /// <summary>
        /// Total vat amount
        /// </summary>
        public decimal? TotalVAT { get; set; }
        public bool ShouldSerializeTotalVAT() => false;

        /// <summary>
        /// If offer row price exclude or include vat
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
        /// ReferenceNumber
        /// </summary>
        public string YourReferenceNumber { get; set; }

        /// <summary>
        /// Zip code 
        /// </summary>
        public string ZipCode { get; set; }
    }
}

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
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public bool ShouldSerializeUrl() => false;

        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }

        public bool ShouldSerializeUrlTaxReductionList() => false;

        public int? AdministrationFee { get; set; }

        public int? AdministrationFeeVAT { get; set; }

        public bool ShouldSerializeAdministrationFeeVAT() => false;

        public string Address1 { get; set; }
        
        public string Address2 { get; set; }

        public int? BasisTaxReduction { get; set; }

        public bool ShouldSerializeBasisTaxReduction() => false;


        public bool Cancelled { get; set; }

        public bool ShouldSerializeCancelled() => false;

        public string City { get; set; }
        
        public string Comments { get; set; }

        public int? ContributionPercent { get; set; }

        public bool ShouldSerializeContributionPercent() => false;

        public int? ContributionValue { get; set; }

        public bool ShouldSerializeContributionValue() => false;

        public bool CopyRemarks { get; set; }
        
        public string Country { get; set; }
        
        public string CostCenter { get; set; }
        
        public string Currency { get; set; }
        
        public int? CurrencyRate { get; set; }
        
        public int? CurrencyUnit { get; set; }
        
        public string CustomerName { get; set; }
        
        public string CustomerNumber { get; set; }
        
        public string DeliveryAddress1 { get; set; }
        
        public string DeliveryAddress2 { get; set; }
        
        public string DeliveryCity { get; set; }
        
        public string DeliveryCountry { get; set; }
        
        public DateTime? DeliveryDate { get; set; }
        
        public string DeliveryName { get; set; }
        
        public string DeliveryZipCode { get; set; }
        
        public string DocumentNumber { get; set; }
        
        public EmailInformation EmailInformation { get; set; }
        
        public string ExpireDate { get; set; }
        
        public int? Freight { get; set; }

        public int? FreightVAT { get; set; }

        public bool ShouldSerializeFreightVAT() => false;

        public int? Gross { get; set; }

        public bool ShouldSerializeGross() => false;

        public bool? HouseWork { get; set; }

        public bool ShouldSerializeHouseWork() => false;

        public int? InvoiceReference { get; set; }
        
        public string Language { get; set; }

        public int? Net { get; set; }

        public bool ShouldSerializeNet() => false;

        public bool NotCompleted { get; set; }
        
        public string OfferDate { get; set; }
        
        public List<OfferRow> OfferRows { get; set; }

        public int? OrderReference { get; set; }

        public bool ShouldSerializeOrderReference() => false;

        public string OrganisationNumber { get; set; }

        public string OurReference { get; set; }

        public bool ShouldSerializeOurReference() => false;

        public string Phone1 { get; set; }
        
        public string Phone2 { get; set; }
        
        public string PriceList { get; set; }
        
        public string PrintTemplate { get; set; }
        
        public string Project { get; set; }
        
        public string Remarks { get; set; }

        public decimal? RoundOff { get; set; }

        public bool ShouldSerializeRoundOff() => false;

        public bool Sent { get; set; }

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

        public int? Total { get; set; }

        public bool ShouldSerializeTotal() => false;

        public int? TotalToPay { get; set; }

        public bool ShouldSerializeTotalToPay() => false;

        public int? TotalVAT { get; set; }

        public bool ShouldSerializeTotalVAT() => false;

        public bool VATIncluded { get; set; }
        
        public string WayOfDelivery { get; set; }
        
        public string YourReference { get; set; }
        
        public string YourReferenceNumber { get; set; }

        public string ZipCode { get; set; }
    }
}

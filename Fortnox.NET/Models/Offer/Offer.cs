using FortnoxNET.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxNET.Models.Offer
{

    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonPropertyClass("Offer")]
    public class Offer
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        [JsonReadOnly]
        [JsonProperty(PropertyName = "@urlTaxReductionList")]
        public string UrlTaxReductionList { get; set; }
        
        public int AdministrationFee { get; set; }

        [JsonReadOnly]
        public int AdministrationFeeVAT { get; set; }
        
        public string Address1 { get; set; }
        
        public string Address2 { get; set; }

        [JsonReadOnly]
        public int BasisTaxReduction { get; set; }

        [JsonReadOnly]
        public bool Cancelled { get; set; }
        
        public string City { get; set; }
        
        public string Comments { get; set; }

        [JsonReadOnly]
        public int ContributionPercent { get; set; }

        [JsonReadOnly]
        public int ContributionValue { get; set; }
        
        public bool CopyRemarks { get; set; }
        
        public string Country { get; set; }
        
        public string CostCenter { get; set; }
        
        public string Currency { get; set; }
        
        public int CurrencyRate { get; set; }
        
        public int CurrencyUnit { get; set; }
        
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
        
        public int Freight { get; set; }

        [JsonReadOnly]
        public int FreightVAT { get; set; }

        [JsonReadOnly]
        public int Gross { get; set; }

        [JsonReadOnly]
        public bool HouseWork { get; set; }
        
        public int InvoiceReference { get; set; }
        
        public string Language { get; set; }

        [JsonReadOnly]
        public int Net { get; set; }
        
        public bool NotCompleted { get; set; }
        
        public string OfferDate { get; set; }
        
        public List<OfferRow> OfferRows { get; set; }

        [JsonReadOnly]
        public int OrderReference { get; set; }
        
        public string OrganisationNumber { get; set; }

        [JsonReadOnly]
        public string OurReference { get; set; }
        
        public string Phone1 { get; set; }
        
        public string Phone2 { get; set; }
        
        public string PriceList { get; set; }
        
        public string PrintTemplate { get; set; }
        
        public string Project { get; set; }
        
        public string Remarks { get; set; }

        [JsonReadOnly]
        public int RoundOff { get; set; }
        
        [JsonReadOnly]
        public bool Sent { get; set; }

        [JsonReadOnly]
        public decimal? TaxReduction { get; set; }
        
        public string TermsOfDelivery { get; set; }
        
        public string TermsOfPayment { get; set; }

        [JsonReadOnly]
        public int Total { get; set; }

        [JsonReadOnly]
        public int TotalToPay { get; set; }

        [JsonReadOnly]
        public int TotalVAT { get; set; }
        
        public bool VATIncluded { get; set; }
        
        public string WayOfDelivery { get; set; }
        
        public string YourReference { get; set; }
        
        public string YourReferenceNumber { get; set; }

        public string ZipCode { get; set; }
    }
}

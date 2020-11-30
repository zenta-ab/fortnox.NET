using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Invoice
{
    [JsonConverter(typeof(CustomJsonConverter))]
    public class InvoiceRow
    {
        /// <summary>
        /// Account number. If not provided the predefined account will be used.
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Article number
        /// </summary>
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Contribution Percent
        /// </summary>
        [JsonReadOnly]
        public decimal ContributionPercent { get; set; }

        /// <summary>
        /// Contribution Value
        /// </summary>
        [JsonReadOnly]
        public decimal ContributionValue { get; set; }

        /// <summary>
        /// Code of the cost center for the row. The code must be of an existing cost center
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Delivered quantity
        /// </summary>
        public decimal DeliveredQuantity { get; set; }

        /// <summary>
        /// Row description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Discount amount
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The type of discount used for the row. Can be AMOUNT or PERCENT
        /// </summary>
        public string DiscountType { get; set; }

        /// <summary>
        /// If the row is housework
        /// </summary>
        public bool HouseWork { get; set; }

        /// <summary>
        /// Hours to be reported if the quantity of the row should not be used as hours.
        /// Can only contain numeric values without decimals
        /// </summary>
        public int? HouseWorkHoursToReport { get; set; }

        /// <summary>
        /// The type of house work. Can be
        /// CONSTRUCTION ELECTRICITY GLASSMETALWORK
        /// GROUNDDRAINAGEWORK MASONRY
        /// PAINTINGWALLPAPERING HVAC MAJORAPPLIANCEREPAIR
        /// MOVINGSERVICES ITSERVICES CLEANING TEXTILECLOTHING SNOWPLOWING
        /// GARDENING BABYSITTING OTHERCARE OTHERCOSTS or empty.
        /// </summary>
        public string HouseWorkType { get; set; }

        /// <summary>
        /// Price per unit
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Price per unit excluding VAT (regardless of value of VATIncluded flag)
        /// </summary>
        [JsonReadOnly]
        public decimal? PriceExcludingVAT { get; set; }

        /// <summary>
        /// Code of the project for the row. The code must be of an existing project.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Stock point that the items has been taken from.
        /// </summary>
        public string StockPointCode { get; set; }

        /// <summary>
        /// Total amount for the row
        /// </summary>
        [JsonReadOnly]
        public decimal? Total { get; set; }

        /// <summary>
        /// Total amount for the row excluding VAT (regardless of value of VATIncluded flag)
        /// </summary>
        [JsonReadOnly]
        public decimal? TotalExcludingVAT { get; set; }

        /// <summary>
        /// Code of the unit for the row. The code must be of an existing unit.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// VAT percentage of the row. The percentage needs to be of an existing VAT percentage.
        /// </summary>
        public decimal VAT { get; set; }
    }
}
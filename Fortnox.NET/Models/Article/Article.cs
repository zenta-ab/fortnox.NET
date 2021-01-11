using Fortnox.NET.Models.Common;
using FortnoxNET.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Article
{
    [JsonPropertyClass("Article")]
    public class Article : ArticleSubset
    {
        /// <summary>
        /// If the article is active
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// If the article is bulky.
        /// </summary>
        public bool? Bulky { get; set; }

        /// <summary>
        /// Account number for construction work (special VAT rules in Sweden). The number must be of an existing account.
        /// </summary>
        public int? ConstructionAccount { get; set; }

        /// <summary>
        /// The depth of the article in millimeters.
        /// </summary>
        public int? Depth { get; set; }

        /// <summary>
        /// Account number for the sales account to EU. The number must be of an existing account.
        /// </summary>
        public int? EUAccount { get; set; }

        /// <summary>
        /// Account number for the sales account to EU with VAT. The number must be of an existing account.
        /// </summary>
        public int? EUVATAccount { get; set; }

        /// <summary>
        /// Account number for the sales account outside EU. The number must be of an existing account.
        /// </summary>
        public int? ExportAccount { get; set; }

        /// <summary>
        /// The height of the article in millimeters.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// The type of house work.
        /// </summary> 
        [JsonConverter(typeof(StringEnumConverter))]
        public HouseworkType? HouseworkType { get; set; }

        /// <summary>
        /// The manufacturer of the article
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// The manufacturers article number.
        /// </summary>
        public string ManufacturerArticleNumber { get; set; }

        /// <summary>
        /// Text note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Account number for purchase. The number must be of an existing account.
        /// </summary>
        public int? PurchaseAccount { get; set; }

        /// <summary>
        /// Account number for the sales account in Sweden. The number must be of an existing account.
        /// </summary>
        public int? SalesAccount { get; set; }

        /// <summary>
        /// If the article is stock goods.
        /// </summary>
        public bool? StockGoods { get; set; }

        /// <summary>
        /// When to start warning for low quantity in stock.
        /// </summary>
        public decimal? StockWarning { get; set; }

        /// <summary>
        /// Name of the supplier.
        /// </summary>
        [JsonReadOnly]
        public string SupplierName { get; set; }

        /// <summary>
        /// Supplier number for the article. The number must be of an existing supplier.
        /// </summary>
        public string SupplierNumber { get; set; }

        /// <summary>
        /// The type of the article. Can be STOCK or SERVICE.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ArticleType? Type { get; set; }

        /// <summary>
        /// VAT percent, this is predefined by the VAT for the sales account.
        /// </summary>
        public decimal? VAT { get; set; }

        /// <summary>
        /// Weight of the article in grams.
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Width of the article in millimeters.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// If the article has expired.
        /// </summary>
        public bool? Expired { get; set; }

        /// <summary>
        /// Method for setting purchase price on the article, either manually by setting 
        /// DirectCost, FreightCost and OtherCost manually (MANUAL), 
        /// or automatically updated by the cost used in the lastest inbound delivery for the article (LAST_RELEASED_INBOUND )
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CostCalculationMethod? CostCalculationMethod { get; set; }

        /// <summary>
        /// Custom bookkeeping account used for stock for the article
        /// </summary>
        public int? StockAccount { get; set; }

        /// <summary>
        /// Purchase price � Direct cost
        /// </summary>
        public decimal? DirectCost { get; set; }

        /// <summary>
        /// Purchase price � Freight cost
        /// </summary>
        public decimal? FreightCost { get; set; }

        /// <summary>
        /// Purchase price � Other cost
        /// </summary>
        public decimal? OtherCost { get; set; }
    }
}
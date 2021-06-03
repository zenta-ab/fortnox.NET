using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Article
{
    [JsonPropertyClass("Articles")]
    public class ArticleSubset
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <summary>
        /// Article number. If no article number is provided, 
        /// the next number in the series will be used. 
        /// Only alpha numeric characters, 
        /// with the addition of � + /  . and _, are allowed.
        /// </summary>
        public string ArticleNumber { get; set; }

        /// <summary>
        /// The description of the article.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Disposable quantity of the article.
        /// </summary>
        [JsonReadOnly]
        public decimal? DisposableQuantity { get; set; }

        /// <summary>
        /// EAN bar code.
        /// </summary>
        public string EAN { get; set; }

        /// <summary>
        /// If the article is housework.
        /// </summary>
        public bool? Housework { get; set; }

        /// <summary>
        /// Purchase price of the article.
        /// </summary>
        public decimal? PurchasePrice { get; set; }

        /// <summary>
        /// Quantity in stock of the article.
        /// </summary>
        public decimal? QuantityInStock { get; set; }

        /// <summary>
        /// Reserved quantity of the article.
        /// </summary>
        [JsonReadOnly]
        public decimal? ReservedQuantity { get; set; }

        /// <summary>
        /// Price of article for its default price list.
        /// </summary>
        [JsonReadOnly]
        public decimal? SalesPrice { get; set; }

        /// <summary>
        /// Storage place for the article.
        /// </summary>
        public string StockPlace { get; set; }

        /// <summary>
        /// Value in stock of the article.
        /// </summary>
        [JsonReadOnly]
        public decimal? StockValue { get; set; }

        /// <summary>
        /// Unit code for the article. The code must be of an existing unit.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// If the article is a webshop article.
        /// </summary>
        public bool? WebshopArticle { get; set; }
    }
}
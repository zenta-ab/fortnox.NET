using FortnoxNET.Utils;

namespace Fortnox.NET.Models.Assets
{
    [JsonPropertyClass("Asset")]
    public class SellAsset
    {
        /// <summary>
        /// Percentage
        /// </summary>
        public int Percentage { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; }
    }
}

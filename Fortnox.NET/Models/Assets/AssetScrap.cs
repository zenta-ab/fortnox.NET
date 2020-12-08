using FortnoxNET.Utils;
using System;

namespace Fortnox.NET.Models.Assets
{
    [JsonPropertyClass("Asset")]
    public class AssetScrap
    {
        /// <summary>
        /// Scrap percentage
        /// </summary>
        public int Percentage { get; set; }

        /// <summary>
        /// Scrap comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Scrap date
        /// </summary>
        public DateTime Date { get; set; }
    }
}

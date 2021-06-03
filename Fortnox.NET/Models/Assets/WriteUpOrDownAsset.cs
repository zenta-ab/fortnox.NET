using FortnoxNET.Utils;
using System;

namespace FortnoxNET.Models.Assets
{
    [JsonPropertyClass("Asset")]
    public class WriteUpOrDownAsset
    {
        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
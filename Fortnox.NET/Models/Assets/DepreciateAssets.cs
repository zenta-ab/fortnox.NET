
using FortnoxNET.Utils;
using System;
using System.Collections.Generic;

namespace Fortnox.NET.Models.Assets
{
    [JsonPropertyClass("Asset")]
    public class DepreciateAssets
    {
        /// <summary>
        /// Date for assets to be depreciated to
        /// </summary>
        public DateTime DepreciateUntil { get; set; }

        /// <summary>
        /// List of IDs for assets to depreciate
        /// </summary>
        public List<int> AssetIds { get; set; }
    }
}

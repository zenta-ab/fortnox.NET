
using FortnoxNET.Utils;
using System.Collections.Generic;

namespace Fortnox.NET.Models.Assets
{
    [JsonPropertyClass("Asset")]
    public class DepreciateAssets
    {
        public string DepreciateUntil { get; set; }

        public List<int> AssetIds { get; set; }
    }
}

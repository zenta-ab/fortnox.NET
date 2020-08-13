using FortnoxNET.Utils;

namespace Fortnox.NET.Models.Assets
{
    [JsonPropertyClass("Asset")]
    public class AssetScrap
    {
        public int Percentage { get; set; }

        public string Comment { get; set; }

        public string Date { get; set; }
    }
}

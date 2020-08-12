using FortnoxNET.Utils;

namespace Fortnox.NET.Models.Assets
{
    [JsonPropertyClass("Asset")]
    public class SellAsset
    {
        public int Percentage { get; set; }

        public int Price { get; set; }

        public string Comment { get; set; }

        public string Date { get; set; }
    }
}

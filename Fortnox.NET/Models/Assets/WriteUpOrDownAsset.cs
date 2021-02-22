using FortnoxNET.Utils;
using System;

namespace FortnoxNET.Models.Assets
{
    [JsonPropertyClass("Asset")]
    public class WriteUpOrDownAsset
    {
        public double Amount { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }
    }
}
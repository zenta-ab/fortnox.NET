
using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.VoucherSeries
{
    [JsonPropertyClass("VoucherSeriesCollection")]
    public class VoucherSeriesSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@Url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool Manual { get; set; }

        public int Year { get; set; }
    }
}

using FortnoxNET.Utils;

namespace FortnoxNET.Models.AccountChart
{
    [JsonPropertyClass("AccountCharts")]
    public class AccountChart
    {
        [JsonReadOnly]
        public string Name { get; set; }
    }
}

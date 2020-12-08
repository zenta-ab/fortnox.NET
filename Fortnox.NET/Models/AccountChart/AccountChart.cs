using FortnoxNET.Utils;

namespace FortnoxNET.Models.AccountChart
{
    [JsonPropertyClass("AccountCharts")]
    public class AccountChart
    {
        /// <summary>
        /// Name of the account chart
        /// </summary>
        [JsonReadOnly]
        public string Name { get; set; }
    }
}

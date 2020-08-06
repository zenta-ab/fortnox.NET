using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Expense
{
    [JsonPropertyClass("Expenses")]
    public class ExpenseSubset
    {
        [JsonReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public string Code { get; set; }

        public string Text { get; set; }

        public int Account { get; set; }

    }
}

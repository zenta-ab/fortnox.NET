using FortnoxNET.Utils;
using Newtonsoft.Json;

namespace FortnoxNET.Models.Expense
{
    [JsonPropertyClass("Expenses")]
    public class ExpenseSubset
    {
        /// <summary>
        /// Direct url to the record.
        /// </summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        public bool ShouldSerializeUrl() => false;

        /// <summary>
        /// Unique expense code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description of expense.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Account number.
        /// </summary>
        public int? Account { get; set; }

    }
}

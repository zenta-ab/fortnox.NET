using FortnoxNET.Utils;

namespace FortnoxNET.Models.Label
{
    [JsonPropertyClass("Labels")]
    public class Label
    {
        /// <summary>
        /// The ID of the label.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description of the label.
        /// </summary>
        public string Description { get; set; }
    }
}

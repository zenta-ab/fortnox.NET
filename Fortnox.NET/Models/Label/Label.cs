using FortnoxNET.Utils;

namespace FortnoxNET.Models.Label
{
    [JsonPropertyClass("Labels")]
    public class Label
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}

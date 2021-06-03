using System.Runtime.Serialization;

namespace FortnoxNET.Models.Article
{
    public enum CostCalculationMethod
    {
        /// <summary>
        /// Manual calculation method
        /// </summary>
        [EnumMember(Value = "MANUAL")]
        MANUAL,

        /// <summary>
        /// Latest inbound delivery calculation method
        /// </summary>
        [EnumMember(Value = "LAST_RELEASED_INBOUND")]
        LAST_RELEASED_INBOUND
    }
}
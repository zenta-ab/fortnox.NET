using System.Runtime.Serialization;

namespace FortnoxNET.Models.Offer
{
    public enum DiscountType
    {
        /// <summary>
        /// Amount
        /// </summary>
        [EnumMember(Value = "AMOUNT")]
        Amount,

        /// <summary>
        /// Percent
        /// </summary>
        [EnumMember(Value = "PERCENT")]
        Percent,
    }
}

using System.Runtime.Serialization;

namespace FortnoxNET.Models.Order
{
    public enum OrderType
    {
        /// <summary>
        /// Order
        /// </summary>
        [EnumMember(Value = "Order")]
        Order,

        /// <summary>
        /// Backorder
        /// </summary>
        [EnumMember(Value = "Backorder")]
        Backorder,
    }
}

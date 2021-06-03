using System.Runtime.Serialization;

namespace FortnoxNET.Models.Customer
{
    public enum DeliveryType
    {
        /// <summary>
        /// Print
        /// </summary>
        [EnumMember(Value = "PRINT")]
        PRINT,

        /// <summary>
        /// Email
        /// </summary>
        [EnumMember(Value = "EMAIL")]
        EMAIL,

        /// <summary>
        /// Print service
        /// </summary>
        [EnumMember(Value = "PRINTSERVICE")]
        PRINTSERVICE,

        /// <summary>
        /// Electronic invoice
        /// </summary>
        [EnumMember(Value = "ELECTRONICINVOICE")]
        ELECTRONICINVOICE
    }
}
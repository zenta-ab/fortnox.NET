using System.Runtime.Serialization;

namespace FortnoxNET.Models.Customer
{
    public enum CustomerType
    {
        /// <summary>
        /// Private
        /// </summary>
        [EnumMember(Value = "PRIVATE")]
        PRIVATE,

        /// <summary>
        /// Company
        /// </summary>
        [EnumMember(Value = "COMPANY")]
        COMPANY,

        /// <summary>
        /// Undefined
        /// </summary>
        [EnumMember(Value = "UNDEFINED")]
        UNDEFINED
    }
}
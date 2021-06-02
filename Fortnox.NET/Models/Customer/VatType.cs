using System.Runtime.Serialization;

namespace FortnoxNET.Models.Customer
{
    public enum VATType
    {
        /// <summary>
        /// SE vat
        /// </summary>
        [EnumMember(Value = "SEVAT")]
        SEVAT,

        /// <summary>
        /// SE reversed vat
        /// </summary>
        [EnumMember(Value = "SEREVERSEDVAT")]
        SEREVERSEDVAT,

        /// <summary>
        /// EU reversed vat
        /// </summary>
        [EnumMember(Value = "EUREVERSEDVAT")]
        EUREVERSEDVAT,

        /// <summary>
        /// EU vat
        /// </summary>
        [EnumMember(Value = "EUVAT")]
        EUVAT,

        /// <summary>
        /// Export
        /// </summary>
        [EnumMember(Value = "EXPORT")]
        EXPORT
    }
}
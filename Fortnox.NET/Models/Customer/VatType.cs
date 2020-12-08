using System.Runtime.Serialization;

namespace FortnoxNET.Models.Customer
{
    public enum VATType
    {
        [EnumMember(Value = "SEVAT")]
        SEVAT,

        [EnumMember(Value = "SEREVERSEDVAT")]
        SEREVERSEDVAT,

        [EnumMember(Value = "EUREVERSEDVAT")]
        EUREVERSEDVAT,

        [EnumMember(Value = "EUVAT")]
        EUVAT,

        [EnumMember(Value = "EXPORT")]
        EXPORT
    }
}
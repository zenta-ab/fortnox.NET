using System.Runtime.Serialization;

namespace FortnoxNET.Models.Customer
{
    public enum CustomerType
    {
        [EnumMember(Value = "PRIVATE")]
        PRIVATE,

        [EnumMember(Value = "COMPANY")]
        COMPANY,

        [EnumMember(Value = "UNDEFINED")]
        UNDEFINED
    }
}
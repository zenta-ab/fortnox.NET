using System.Runtime.Serialization;

namespace FortnoxNET.Models.Customer
{
    public enum DeliveryType
    {
        [EnumMember(Value = "PRINT")]
        PRINT,

        [EnumMember(Value = "EMAIL")]
        EMAIL,

        [EnumMember(Value = "PRINTSERVICE")]
        PRINTSERVICE
    }
}
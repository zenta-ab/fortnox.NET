using System.Runtime.Serialization;

namespace FortnoxNET.Models.TaxReduction
{
    public enum ReferenceDocumentType
    {
        /// <summary>
        /// Offer
        /// </summary>
        [EnumMember(Value = "OFFER")]
        Offer,
        
        /// <summary>
        /// Order
        /// </summary>
        [EnumMember(Value = "ORDER")]
        Order,
        
        /// <summary>
        /// Invoice
        /// </summary>
        [EnumMember(Value = "INVOICE")]
        Invoice,
    }
}

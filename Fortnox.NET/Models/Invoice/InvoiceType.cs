using System.Runtime.Serialization;

namespace FortnoxNET.Models.Invoice
{
    public enum InvoiceType
    {
        /// <summary>
        /// Invoice
        /// </summary>
        [EnumMember(Value = "INVOICE")]
        INVOICE,

        /// <summary>
        /// Agreement invoice
        /// </summary>
        [EnumMember(Value = "AGREEMENTINVOICE")]
        AGREEMENTINVOICE,

        /// <summary>
        /// Interest invoice
        /// </summary>
        [EnumMember(Value = "INTRESTINVOICE")]
        INTRESTINVOICE,

        /// <summary>
        /// Summary invoice
        /// </summary>
        [EnumMember(Value = "SUMMARYINVOICE")]
        SUMMARYINVOICE,

        /// <summary>
        /// Cash invoice
        /// </summary>
        [EnumMember(Value = "CASHINVOICE")]
        CASHINVOICE
    }
}

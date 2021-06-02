using System.Runtime.Serialization;

namespace FortnoxNET.Models.Vouchers
{
    public enum ReferenceType
    {
        /// <summary>
        /// Invoice
        /// </summary>
        [EnumMember(Value = "INVOICE")]
        Invoice,

        /// <summary>
        /// Supplier invoice
        /// </summary>
        [EnumMember(Value = "SUPPLIERINVOICE")]
        SupplierInvoice,

        /// <summary>
        /// Invoice payment
        /// </summary>
        [EnumMember(Value = "INVOICEPAYMENT")]
        InvoicePayment,

        /// <summary>
        /// Supplier payment
        /// </summary>
        [EnumMember(Value = "SUPPLIERPAYMENT")]
        SupplierPayment,

        /// <summary>
        /// Manual
        /// </summary>
        [EnumMember(Value = "MANUAL")]
        Manual,

        /// <summary>
        /// Cash invoice
        /// </summary>
        [EnumMember(Value = "CASHINVOICE")]
        CashInvoice,

        /// <summary>
        /// Accrual
        /// </summary>
        [EnumMember(Value = "ACCRUAL")]
        Accrual,
    }
}

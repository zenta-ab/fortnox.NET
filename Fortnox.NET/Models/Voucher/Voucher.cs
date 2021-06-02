using System;
using System.Collections.Generic;
using FortnoxNET.Models.Vouchers;

namespace FortnoxNET.Models.Voucher
{
    public class Voucher : VoucherSubset
    {
        /// <summary>
        ///  Comments of the voucher
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Code of the cost center
        /// </summary>
        public string CostCenter { get; set; }

        /// <summary>
        /// Code of the project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date of the transaction
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Date of the transaction
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// The properties for the object in this array is listed in the table for “Voucher Rows”
        /// </summary>
        public IEnumerable<VoucherInvoiceRow> VoucherRows { get; set; }
    }
}
using System;
using System.Collections.Generic;
using FortnoxNET.Models.Vouchers;

namespace FortnoxNET.Models.Voucher
{
    public class Voucher : VoucherSubset
    {
        public string Comments { get; set; }
        public string CostCenter { get; set; }
        public string Description { get; set; }
        public int Project { get; set; }
        public DateTime TransactionDate { get; set; }
        public IEnumerable<VoucherInvoiceRow> VoucherRows { get; set; }
    }
}
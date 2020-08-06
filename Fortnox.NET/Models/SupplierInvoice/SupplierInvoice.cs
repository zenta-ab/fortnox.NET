using System;
using System.Collections.Generic;
using FortnoxNET.Models.Vouchers;

namespace FortnoxNET.Models.SupplierInvoice
{
    public class SupplierInvoice : SupplierInvoiceSubset
    {
        public IEnumerable<SupplierInvoiceRow> SupplierInvoiceRows { get; set; }
        public decimal VAT { get; set; }
        public string YourReference { get; set; }
        public int VoucherNumber { get; set; }
        public string VoucherSeries { get; set; }
        public int VoucherYear { get; set; }
        public string VATType { get; set; }
        public string SalesType { get; set; }

    }
}
using System;
using System.Collections.Generic;
using FortnoxNET.Models.Vouchers;

namespace FortnoxNET.Models.InvoicePayment
{
    public class InvoicePayment : InvoicePaymentSubset
    {

        public int AmountCurrency { get; set; }
        public string ExternalInvoiceReference1 { get; set; }
        public string ExternalInvoiceReference2 { get; set; }
        public string InvoiceCustomerName { get; set; }
        public string InvoiceCustomerNumber { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public string InvoiceOCR { get; set; }
        public string InvoiceTotal { get; set; }
        public string ModeOfPayment { get; set; }
        public int ModeOfPaymentAccount { get; set; }
        public int? VoucherNumber { get; set; }
        public string VoucherSeries { get; set; }
        public int? VoucherYear { get; set; }
        public List<WriteOff> WriteOffs { get; set; }
    }
}
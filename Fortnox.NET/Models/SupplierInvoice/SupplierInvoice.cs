using System;
using System.Collections.Generic;
using FortnoxNET.Models.Vouchers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.SupplierInvoice
{
    public class SupplierInvoice : SupplierInvoiceSubset
    {
        /// <summary>
        /// Supplier invoice rows
        /// </summary>
        public IEnumerable<SupplierInvoiceRow> SupplierInvoiceRows { get; set; }

        /// <summary>
        /// Vat amount
        /// </summary>
        public decimal? VAT { get; set; }

        /// <summary>
        /// Customer reference
        /// </summary>
        public string YourReference { get; set; }

        /// <summary>
        /// Voucher number for the invoice.
        /// </summary>
        public int? VoucherNumber { get; set; }

        /// <summary>
        /// Voucher series for the invoice.
        /// </summary>
        public string VoucherSeries { get; set; }

        /// <summary>
        /// Voucher year for the invoice.
        /// </summary>
        public int? VoucherYear { get; set; }

        /// <summary>
        /// Vat type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public VATType? VATType { get; set; }

        /// <summary>
        /// Sales type
        /// </summary>
        public string SalesType { get; set; }
    }
}
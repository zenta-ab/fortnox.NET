using FortnoxNET.Utils;
using System;

namespace FortnoxNET.Models.Assets
{
    public class History
    {
        /// <summary>
        /// Id of history record
        /// </summary>
        [JsonReadOnly]
        public int Id { get; set; }

        /// <summary>
        /// Date of event
        /// </summary>
        [JsonReadOnly]
        public DateTime Date { get; set; }

        /// <summary>
        /// Event type Id
        /// </summary>
        [JsonReadOnly]
        public int EventId { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        [JsonReadOnly]
        public string Amount { get; set; }

        /// <summary>
        /// User Id that performed that operation
        /// </summary>
        [JsonReadOnly]
        public int UserId { get; set; }

        /// <summary>
        /// User name that performed that operation
        /// </summary>
        [JsonReadOnly]
        public string UserName { get; set; }

        /// <summary>
        /// 	Notes for performed operation or event
        /// </summary>
        [JsonReadOnly]
        public string Notes { get; set; }

        /// <summary>
        /// Reference to voucher number
        /// </summary>
        [JsonReadOnly]
        public int? VoucherNumber { get; set; }

        /// <summary>
        /// Reference to voucher series
        /// </summary>
        [JsonReadOnly]
        public string VoucherSeries { get; set; }

        /// <summary>
        /// Reference to voucher year
        /// </summary>
        [JsonReadOnly]
        public int? VoucherYear { get; set; }

        /// <summary>
        /// Reference to supplier invoice if it exists
        /// </summary>
        [JsonReadOnly]
        public int SupplierInvoice { get; set; }
    }
}
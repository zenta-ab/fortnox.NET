namespace FortnoxNET.Models.Customer
{
    public class DefaultTemplates
    {
        /// <summary>
        /// Default template for cash invoices.
        /// Must be a name of an existing print template.
        /// </summary>
        public string CashInvoice { get; set; }

        /// <summary>
        /// Default template for invoices. 
        /// Must be a name of an existing print template.
        /// </summary>
        public string Invoice { get; set; }

        /// <summary>
        /// Default template for offers. 
        /// Must be a name of an existing print template.
        /// </summary>
        public string Offer { get; set; }

        /// <summary>
        /// Default template for orders. 
        /// Must be a name of an existing print template.
        /// </summary>
        public string Order { get; set; }
    }
}
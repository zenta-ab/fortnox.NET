namespace FortnoxNET.Models.Customer
{
    public class DefaultDeliveryTypes
    {
        /// <summary>
        /// Default delivery type for invoices. 
        /// Can be PRINT EMAIL or PRINTSERVICE.
        /// </summary>
        public DeliveryType Invoice { get; set; }

        /// <summary>
        /// Default delivery type for orders. 
        /// Can be PRINT EMAIL or PRINTSERVICE.
        /// </summary>
        public DeliveryType Order { get; set; }

        /// <summary>
        /// Default delivery type for offers. 
        /// Can be PRINT EMAIL or PRINTSERVICE.
        /// </summary>
        public DeliveryType Offer { get; set; }
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FortnoxNET.Models.Customer
{
    public class DefaultDeliveryTypes
    {
        /// <summary>
        /// Default delivery type for invoices. 
        /// Can be PRINT EMAIL or PRINTSERVICE.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryType Invoice { get; set; }

        /// <summary>
        /// Default delivery type for orders. 
        /// Can be PRINT EMAIL or PRINTSERVICE.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryType Order { get; set; }

        /// <summary>
        /// Default delivery type for offers. 
        /// Can be PRINT EMAIL or PRINTSERVICE.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryType Offer { get; set; }
    }
}
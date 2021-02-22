using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.WebSockets.Models
{
    public class WebSocketTopicStringValueAttribute : System.Attribute
    {
        private string _value;

        public WebSocketTopicStringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }

    public enum WebSocketTopic
    {
        [WebSocketTopicStringValue("invoices")]
        Invoices,
        [WebSocketTopicStringValue("customers")]
        Customers,
        [WebSocketTopicStringValue("orders")]
        Orders,
        [WebSocketTopicStringValue("offers")]
        Offers,
        [WebSocketTopicStringValue("articles")]
        Articles,
        [WebSocketTopicStringValue("currencies")]
        Currencies,
        [WebSocketTopicStringValue("termsofdeliveries")]
        TermsOfDeliveries,
        [WebSocketTopicStringValue("waysofdeliveries")]
        WaysOfDeliveries,
        [WebSocketTopicStringValue("termsofpayments")]
        TermsOfPayments,
    }
}

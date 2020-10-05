using System.Runtime.Serialization;

namespace Fortnox.NET.WebSockets.Models
{
    public enum WebSocketEventType
    {
        [EnumMember(Value = "invoice-created-v1")]
        InvoiceCreated,
        [EnumMember(Value = "invoice-updated-v1")]
        InvoiceUpdated,
        [EnumMember(Value = "invoice-cancelled-v1")]
        InvoiceCancelled,
        [EnumMember(Value = "invoicepayment-bookkeep-v1")]
        InvoicePaymentBookkeep,
        [EnumMember(Value = "invoicepayment-deleted-v1")]
        InvoicePaymentDeleted,
        [EnumMember(Value = "reminder-sent-v1")]
        ReminderSentV1,
        [EnumMember(Value = "reminder-sent-v2")]
        ReminderSent,

        [EnumMember(Value = "customer-created-v1")]
        CustomerCreated,
        [EnumMember(Value = "customer-updated-v1")]
        CustomerUpdated,
        [EnumMember(Value = "customer-deleted-v1")]
        CustomerDeleted,

        [EnumMember(Value = "order-created-v1")]
        OrderCreated,
        [EnumMember(Value = "order-updated-v1")]
        OrderUpdated,
        [EnumMember(Value = "order-cancelled-v1")]
        OrderCancelled,

        [EnumMember(Value = "offer-created-v1")]
        OfferCreated,
        [EnumMember(Value = "offer-updated-v1")]
        OfferUpdated,

        [EnumMember(Value = "article-created-v1")]
        ArticleCreated,
        [EnumMember(Value = "article-updated-v1")]
        ArticleUpdated,
        [EnumMember(Value = "article-deleted-v1")]
        ArticleDeleted,

        [EnumMember(Value = "currency-created-v1")]
        CurrencyCreated,
        [EnumMember(Value = "currency-updated-v1")]
        CurrencyUpdated,
        [EnumMember(Value = "currency-deleted-v1")]
        CurrencyDeleted,

        [EnumMember(Value = "termofdelivery-created-v1")]
        TermOfDeliveryCreated,
        [EnumMember(Value = "termofdelivery-updated-v1")]
        TermOfDeliveryUpdated,
        [EnumMember(Value = "termofdelivery-deleted-v1")]
        TermOfDeliveryDeleted,

        [EnumMember(Value = "wayofdelivery-created-v1")]
        WayOfDeliveryCreated,
        [EnumMember(Value = "wayofdelivery-updated-v1")]
        WayOfDeliveryUpdated,
        [EnumMember(Value = "wayofdelivery-deleted-v1")]
        WayOfDeliveryDeleted,

        [EnumMember(Value = "termsofpayments-created-v1")]
        TermsOfPaymentsCreated,
        [EnumMember(Value = "termsofpayments-updated-v1")]
        TermsOfPaymentsUpdated,
        [EnumMember(Value = "termsofpayments-deleted-v1")]
        TermsOfPaymentDeleted,
    }
}

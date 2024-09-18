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
        [EnumMember(Value = "customer-created-v1")]
        CustomerCreated,
        [EnumMember(Value = "customer-updated-v2")]
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

        [EnumMember(Value = "waysofdeliveries-created-v1")]
        WaysOfDeliveriesCreated,
        [EnumMember(Value = "waysofdeliveries-updated-v1")]
        WaysOfDeliveriesUpdated,
        [EnumMember(Value = "waysofdeliveries-deleted-v1")]
        WaysOfDeliveriesDeleted,

        [EnumMember(Value = "termsofpayments-created-v1")]
        TermsOfPaymentsCreated,
        [EnumMember(Value = "termsofpayments-updated-v1")]
        TermsOfPaymentsUpdated,
        [EnumMember(Value = "termsofpayments-deleted-v1")]
        TermsOfPaymentsDeleted,

        [EnumMember(Value = "activity-created-v1")]
        ActivityCreated,
        [EnumMember(Value = "activity-updated-v1")]
        ActivityUpdated,

        [EnumMember(Value = "assignment-created-v1")]
        AssignmentCreated,
        [EnumMember(Value = "assignment-updated-v1")]
        AssignmentUpdated,
        [EnumMember(Value = "assignment-deleted-v1")]
        AssignmentDeleted,

        [EnumMember(Value = "cost-center-created-v1")]
        CostCenterCreated,
        [EnumMember(Value = "cost-center-updated-v1")]
        CostCenterUpdated,
        [EnumMember(Value = "cost-center-deleted-v1")]
        CostCenterDeleted,
      
        [EnumMember(Value = "financial-year-created-v1")]
        FinancialYearCreated,
        [EnumMember(Value = "financial-year-updated-v1")]
        FinancialYearUpdated,
        [EnumMember(Value = "financial-year-deleted-v1")]
        FinancialYearDeleted,

        [EnumMember(Value = "account-created-v1")]
        AccountCreated,
        [EnumMember(Value = "account-updated-v1")]
        AccountUpdated,
        [EnumMember(Value = "account-deleted-v1")]
        AccountDeleted,

        [EnumMember(Value = "invoice-bookkeep-v1")]
        InvoiceBookkeep,

        [EnumMember(Value = "send-push-notification-queued-v1")]
        SendPushNotificationQueued,

        [EnumMember(Value = "offer-canceled-v1")]
        OfferCanceled,

        [EnumMember(Value = "project-created-v1")]
        ProjectCreated,
        [EnumMember(Value = "project-updated-v1")]
        ProjectUpdated,
        [EnumMember(Value = "project-deleted-v1")]
        ProjectDeleted,

        [EnumMember(Value = "supplier-created-v1")]
        SupplierCreated,
        [EnumMember(Value = "supplier-updated-v1")]
        SupplierUpdated,
        [EnumMember(Value = "supplier-deleted-v1")]
        SupplierDeleted,

        [EnumMember(Value = "supplier-invoice-created-v1")]
        SupplierInvoiceCreated,
        [EnumMember(Value = "supplier-invoice-updated-v1")]
        SupplierInvoiceUpdated,
        [EnumMember(Value = "supplier-invoice-cancelled-v1")]
        SupplierInvoiceCancelled,
        [EnumMember(Value = "supplier-invoice-bookkeep-v1")]
        SupplierInvoiceBookkeep,

        [EnumMember(Value = "voucher-created-v1")]
        VoucherCreated,
        [EnumMember(Value = "voucher-updated-v1")]
        VoucherUpdated,
        [EnumMember(Value = "voucher-deleted-v1")]
        VoucherDeleted,

        [EnumMember(Value = "warehouse-stockbalance-changed-v1")]
        WarehouseStockBalanceChanged,
    }
}

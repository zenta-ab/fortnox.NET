namespace FortnoxNET.Constants
{
    public static class ApiEndpoints
    {
        private const string _apiVersion = "3";
        private static readonly string _baseUri = $"https://api.fortnox.se/{_apiVersion}";

        private const string _webSocketApiVersion = "v1";
        public static readonly string WebSocketURI = $"wss://ws.fortnox.se/topics-{_webSocketApiVersion}";

        public static readonly string AbsenceTransactions = $"{_baseUri}/absencetransactions";
		public static readonly string CustomerInvoices = $"{_baseUri}/invoices";
        public static readonly string Vouchers = $"{_baseUri}/vouchers";
        public static readonly string VoucherSublist = $"{_baseUri}/vouchers/sublist";
        public static readonly string Accounts = $"{_baseUri}/accounts";
        public static readonly string SupplierInvoices = $"{_baseUri}/supplierinvoices";
        public static readonly string Customers = $"{_baseUri}/customers";
        public static readonly string Articles = $"{_baseUri}/articles";
        public static readonly string Units = $"{_baseUri}/units";
        public static readonly string Projects = $"{_baseUri}/projects";
        public static readonly string CompanySettings = $"{_baseUri}/settings/company";
        public static readonly string CompanyInformation = $"{_baseUri}/companyinformation";
        public static readonly string Orders = $"{_baseUri}/orders";
        public static readonly string Suppliers = $"{_baseUri}/suppliers";
        public static readonly string Labels = $"{_baseUri}/labels";
        public static readonly string InvoicePayments = $"{_baseUri}/invoicepayments";
        public static readonly string Assets = $"{_baseUri}/assets";
        public static readonly string AssetDepreciations = $"{Assets}/depreciations";
        public static readonly string AssetWriteUps = $"{Assets}/writeup";
        public static readonly string AssetWriteDowns = $"{Assets}/writedown";
        public static readonly string ScrapAsset = $"{Assets}/scrap";
        public static readonly string SellAsset = $"{Assets}/sell";
        public static readonly string Depreciate = $"{Assets}/depreciate";
        public static readonly string Inbox = $"{_baseUri}/inbox";
        public static readonly string SIE = $"{_baseUri}/sie";
        public static readonly string Offers = $"{_baseUri}/offers";
        public static readonly string Invoices = $"{_baseUri}/invoices";
        public static readonly string Expenses = $"{_baseUri}/expenses";
        public static readonly string Currencies = $"{_baseUri}/currencies";
        public static readonly string AccountCharts = $"{_baseUri}/accountcharts";
        public static readonly string AttendanceTransactions = $"{_baseUri}/attendancetransactions";
        public static readonly string CostCenters = $"{_baseUri}/costcenters";
        public static readonly string PriceLists = $"{_baseUri}/pricelists";
        public static readonly string Prices = $"{_baseUri}/prices";
        public static readonly string VoucherSeries = $"{_baseUri}/voucherseries";
        public static readonly string FinancialYears = $"{_baseUri}/financialyears";
        public static readonly string SupplierInvoicePayments = $"{_baseUri}/supplierinvoicepayments";
        public static readonly string SalaryTransactions = $"{_baseUri}/salarytransactions";
        public static readonly string Employees = $"{_baseUri}/employees";
        public static readonly string AssetTypes = $"{_baseUri}/assets/types";
        public static readonly string Contracts = $"{_baseUri}/contracts";
        public static readonly string TaxReductions = $"{_baseUri}/taxreductions";
        public static readonly string WayOfDeliveries = $"{_baseUri}/wayofdeliveries";
        public static readonly string LockedPeriod = $"{_baseUri}/settings/lockedperiod";
        public static readonly string TermsOfDeliveries = $"{_baseUri}/termsofdeliveries";
        public static readonly string TermsOfPayments = $"{_baseUri}/termsofpayments";
        public static readonly string EmailTrustedDomains = $"{_baseUri}/emailtrusteddomains";
        public static readonly string SupplierInvoiceExternalURLConnections = $"{_baseUri}/supplierinvoiceexternalurlconnections";
        public static readonly string ModesOfPayments = $"{_baseUri}/modesofpayments";
        public static readonly string PrintTemplates = $"{_baseUri}/printtemplates";
        public static readonly string Archive = $"{_baseUri}/archive";
        public static readonly string ArticleFileConnections = $"{_baseUri}/articlefileconnections";
        public static readonly string ContractTemplates = $"{_baseUri}/contracttemplates";
        public static readonly string PredefinedAccounts = $"{_baseUri}/predefinedaccounts";
    }
}
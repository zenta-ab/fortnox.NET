namespace FortnoxNET.Models.ContractTemplates
{
    public enum ContractTemplateInvoiceRowDiscountType
    {
        [ContractTemplateInvoiceRowDiscountType("AMOUNT")]
        Amount,
        
        [ContractTemplateInvoiceRowDiscountType("PERCENT")]
        Percent,
    }

    public class ContractTemplateInvoiceRowDiscountTypeAttribute : System.Attribute
    {
        private string _value;

        public ContractTemplateInvoiceRowDiscountTypeAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}
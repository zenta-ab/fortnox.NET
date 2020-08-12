namespace FortnoxNET.Models.ContractAccruals
{
    public enum ContractAccrualPeriod
    {
        [ContractAccrualPeriodValue("MONTHLY")]
        Monthly,
        
        [ContractAccrualPeriodValue("BIMONTHLY")]
        Bimonthly,
        
        [ContractAccrualPeriodValue("QUARTERLY")]
        Quarterly,
        
        [ContractAccrualPeriodValue("SEMIANNUALLY")]
        Semiannually,
        
        [ContractAccrualPeriodValue("ANNUALLY")]
        Annually,
    }
    
    public class ContractAccrualPeriodValueAttribute : System.Attribute
    {
        private string _value;

        public ContractAccrualPeriodValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}
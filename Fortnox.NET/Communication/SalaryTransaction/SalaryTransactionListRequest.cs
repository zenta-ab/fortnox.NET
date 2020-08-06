namespace FortnoxNET.Communication.SalaryTransaction
{
    public class SalaryTransactionListRequest : FortnoxApiListedResourceRequest
    {
        public SalaryTransactionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}

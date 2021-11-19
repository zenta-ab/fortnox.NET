using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.Expenses
{
    public class ExpenseListRequest : FortnoxApiListedResourceRequest
    {
        public ExpenseListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public ExpenseListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}

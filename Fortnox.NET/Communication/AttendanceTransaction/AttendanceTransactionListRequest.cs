using FortnoxApiSDK.Models.Authorization;

namespace FortnoxNET.Communication.AttendanceTransaction
{
    public class AttendanceTransactionListRequest : FortnoxApiListedResourceRequest
    {
        public AttendanceTransactionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public AttendanceTransactionListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}

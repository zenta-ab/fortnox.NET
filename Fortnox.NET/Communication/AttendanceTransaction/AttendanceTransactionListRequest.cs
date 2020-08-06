namespace FortnoxNET.Communication.AttendanceTransaction
{
    public class AttendanceTransactionListRequest : FortnoxApiListedResourceRequest
    {
        public AttendanceTransactionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}

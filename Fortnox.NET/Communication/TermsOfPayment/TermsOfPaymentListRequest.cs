using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication.TermsOfPayment
{
    public class TermsOfPaymentListRequest : FortnoxApiListedResourceRequest
    {
        public TermsOfPaymentListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public TermsOfPaymentSortableProperties? SortBy { get; set; }

    }
}

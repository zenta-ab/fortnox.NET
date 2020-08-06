using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using System.Collections.Generic;

namespace FortnoxNET.Communication.TermsOfDelivery
{
    public class TermsOfDeliveryListRequest : FortnoxApiListedResourceRequest
    {
        public TermsOfDeliveryListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public TermsOfDeliverySortableProperties? SortBy { get; set; }

        public Dictionary<TermsOfDeliverySearchParameters, object> SearchParameters { get; set; }
    }
}

using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using System.Collections.Generic;

namespace FortnoxNET.Communication.Price
{
    public class PriceListRequest : FortnoxApiListedResourceRequest
    {
        public PriceListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public PriceSortableProperties? SortBy { get; set; }

        public Dictionary<PriceSearchParameters, object> SearchParameters { get; set; }
    }
}

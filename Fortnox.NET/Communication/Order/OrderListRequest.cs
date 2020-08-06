using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;
using System.Collections.Generic;

namespace FortnoxNET.Communication.Order
{
    public class OrderListRequest : FortnoxApiListedResourceRequest
    {
        public OrderListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public OrderFilters? Filter { get; set; }

        public OrdersSortableProperties? SortBy { get; set; }

        public Dictionary<OrderSearchParameters, object> SearchParameters { get; set; }
    }
}

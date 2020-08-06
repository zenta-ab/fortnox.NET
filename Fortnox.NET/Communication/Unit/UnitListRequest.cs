using System.Collections.Generic;
using FortnoxNET.Constants.Filter;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication.Unit
{
    public class UnitListRequest : FortnoxApiListedResourceRequest
    {
        public UnitListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
        public UnitSortableProperties? SortBy { get; set; }
        public Dictionary<UnitSearchParameters, object> SearchParameters { get; set; }
    }
}
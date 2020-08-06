using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication.CostCenter
{
    public class CostCenterListRequest : FortnoxApiListedResourceRequest
    {
        public CostCenterListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public CostCenterSortableProperties? SortBy { get; set; }
    }
}

using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication.WayOfDelivery
{
    public class WayOfDeliveryListRequest : FortnoxApiListedResourceRequest
    {
        public WayOfDeliveryListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public WayOfDeliverySortableProperties? SortBy { get; set; }
    }
}

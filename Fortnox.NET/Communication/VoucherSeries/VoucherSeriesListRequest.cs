using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication.VoucherSeries
{
    public class VoucherSeriesListRequest : FortnoxApiListedResourceRequest
    {
        public VoucherSeriesListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public VoucherSeriesListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }

        public VoucherSeriesSortableProperties? SortBy { get; set; }
    }
}

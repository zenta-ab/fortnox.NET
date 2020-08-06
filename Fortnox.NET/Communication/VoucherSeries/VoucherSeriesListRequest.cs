using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication.VoucherSeries
{
    public class VoucherSeriesListRequest : FortnoxApiListedResourceRequest
    {
        public VoucherSeriesListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public VoucherSeriesSortableProperties? SortBy { get; set; }
    }
}

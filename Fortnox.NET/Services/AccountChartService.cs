using FortnoxNET.Communication;
using FortnoxNET.Communication.AccountChart;
using FortnoxNET.Constants;
using FortnoxNET.Models.AccountChart;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class AccountChartService
    {
        public static async Task<ListedResourceResponse<AccountChart>> GetAccountChartsAsync(AccountChartListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<AccountChart>>(HttpMethod.Get, listRequest,
                                                                                        ApiEndpoints.AccountCharts);
            return await FortnoxAPIClient.CallAsync(apiRequest);
        }
    }
}

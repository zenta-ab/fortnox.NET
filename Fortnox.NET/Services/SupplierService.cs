using FortnoxNET.Communication;
using FortnoxNET.Communication.Supplier;
using FortnoxNET.Constants;
using FortnoxNET.Models.Supplier;
using System.Net.Http;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class SupplierService
    {
        public static async Task<ListedResourceResponse<SupplierSubset>> GetSuppliersAsync(SupplierListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<SupplierSubset>>(HttpMethod.Get, listRequest,
                                                                                                 ApiEndpoints.Suppliers);

            apiRequest.SetSortOrder(listRequest.SortBy?.ToString(), listRequest.SortOrder.ToString());
            apiRequest.SetPageAndLimit(listRequest.Page, listRequest.Limit);

            if (listRequest.SearchParameters == null)
            {
                return await FortnoxAPIClient.CallAsync(apiRequest);
            }

            foreach (var param in listRequest.SearchParameters)
            {
                apiRequest.AddSearchParam(param.Key.ToString().ToLower(), param.Value);
            }

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<Supplier> GetSupplierAsync(FortnoxApiRequest request, string supplierNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Supplier>>(HttpMethod.Get, request,
                                                                                    $"{ApiEndpoints.Suppliers}/{supplierNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}

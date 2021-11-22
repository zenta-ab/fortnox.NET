using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.Customer;

namespace FortnoxNET.Services
{
    public class CustomerService
    {
        public static async Task<ListedResourceResponse<CustomerSubset>> GetCustomersAsync(CustomerListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<CustomerSubset>>(HttpMethod.Get, listRequest,
                                                                                                ApiEndpoints.Customers);

            apiRequest.SetFilter(listRequest.Filter?.ToString());
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
        
        public static async Task<Customer> GetCustomerAsync(FortnoxApiRequest request, string customerNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Customer>>(HttpMethod.Get, request,
                                                                                          $"{ApiEndpoints.Customers}/{customerNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Customer> CreateCustomerAsync(FortnoxApiRequest request, Customer customer)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Customer>>(HttpMethod.Post, request, $"{ApiEndpoints.Customers}")
                {
                    Data = new SingleResource<Customer> {Data = customer}
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Customer> UpdateCustomerAsync(FortnoxApiRequest request, Customer customer)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Customer>>(HttpMethod.Put, request, $"{ApiEndpoints.Customers}/{customer.CustomerNumber}")
                {
                    Data = new SingleResource<Customer> {Data = customer}
                };
            
            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}
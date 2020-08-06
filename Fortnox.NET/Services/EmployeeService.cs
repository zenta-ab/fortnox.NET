using System.Net.Http;
using System.Threading.Tasks;
using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.Employee;

namespace FortnoxNET.Services
{
    public class EmployeeService
    {

        public static async Task<ListedResourceResponse<Employees>> GetEmployeesAsync(EmployeeListRequest listRequest)
        {
            var apiRequest = new FortnoxApiClientRequest<ListedResourceResponse<Employees>>(HttpMethod.Get, listRequest.AccessToken, listRequest.ClientSecret,
                                                                                                ApiEndpoints.Employees);

            apiRequest.SetFilter(listRequest.Filter?.ToString());

            return await FortnoxAPIClient.CallAsync(apiRequest);
        }

        public static async Task<Employee> GetEmployeeAsync(FortnoxApiRequest request, string employeeNumber)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<Employee>>(HttpMethod.Get, request.AccessToken, request.ClientSecret,
                                                                                          $"{ApiEndpoints.Employees}/{employeeNumber}");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Employee> CreateEmployeeAsync(FortnoxApiRequest request, Employee employee)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Employee>>(HttpMethod.Post, request.AccessToken, request.ClientSecret, $"{ApiEndpoints.Employees}")
                {
                    Data = new SingleResource<Employee> { Data = employee }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

        public static async Task<Employee> UpdateEmployeeAsync(FortnoxApiRequest request, Employee employee)
        {
            var apiRequest =
                new FortnoxApiClientRequest<SingleResource<Employee>>(HttpMethod.Put, request.AccessToken, request.ClientSecret,
                                                                   $"{ApiEndpoints.Employees}/{employee.EmployeeId}")
                {
                    Data = new SingleResource<Employee> { Data = employee }
                };

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }

    }
}
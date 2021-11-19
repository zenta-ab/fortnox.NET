using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.LockedPeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class LockedPeriodService
    {
        public static async Task<LockedPeriod> GetLockedPeriodAsync(FortnoxApiRequest request)
        {
            var apiRequest = new FortnoxApiClientRequest<SingleResource<LockedPeriod>>(HttpMethod.Get, request,
                $"{ApiEndpoints.LockedPeriod}/");

            return (await FortnoxAPIClient.CallAsync(apiRequest)).Data;
        }
    }
}

using FortnoxNET.Communication;
using FortnoxNET.Constants;
using FortnoxNET.Models.SIE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Services
{
    public class SIEService
    {
        public static async Task<byte[]> GetSIEAsync(FortnoxApiRequest request, SIETypes type, int? finnancialYear = null)
        {
            var route = $"{ApiEndpoints.SIE}/{(int) type}";

            if (finnancialYear.HasValue)
            {
                route = $"{route}?financialyear={finnancialYear.Value}";
            }

            var apiRequest = new FortnoxApiClientRequest<byte[]>(HttpMethod.Get, request, route);

            return (await FortnoxAPIClient.CallAsync(apiRequest));
        }

        // NOTE: Writes the SIE byte array to the specified file. If the file already exists it is overwritten.
        public static async Task GetAndSaveSIEToDiskAsync(FortnoxApiRequest request, SIETypes type, string filePath, int? finnancialYear = null)
        {
            var route = $"{ApiEndpoints.SIE}/{(int)type}";

            if (finnancialYear.HasValue)
            {
                route = $"{route}?financialyear={finnancialYear.Value}";
            }

            var apiRequest = new FortnoxApiClientRequest<byte[]>(HttpMethod.Get, request, route);
            var resultingByteArray =  await FortnoxAPIClient.CallAsync(apiRequest);

            File.WriteAllBytes(filePath, resultingByteArray);
        }
    }
}

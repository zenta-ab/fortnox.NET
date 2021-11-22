using FortnoxApiSDK.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Communication.AccountChart
{
    public class AccountChartListRequest : FortnoxApiListedResourceRequest
    {
        public AccountChartListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public AccountChartListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}

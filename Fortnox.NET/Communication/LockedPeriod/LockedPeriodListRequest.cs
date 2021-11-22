using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortnoxApiSDK.Models.Authorization;
using FortnoxNET.Constants.Search;
using FortnoxNET.Constants.Sort;

namespace FortnoxNET.Communication.LockedPeriod
{
    public class LockedPeriodListRequest : FortnoxApiListedResourceRequest
    {
        public LockedPeriodListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public LockedPeriodListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}
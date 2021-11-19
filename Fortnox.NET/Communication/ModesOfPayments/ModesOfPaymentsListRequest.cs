using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Communication.ModesOfPayments
{
    public class ModesOfPaymentsListRequest : FortnoxApiListedResourceRequest
    {
        public ModesOfPaymentsListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }

        public ModesOfPaymentsListRequest(OAuthToken oAuthToken) : base(oAuthToken)
        {
        }
    }
}

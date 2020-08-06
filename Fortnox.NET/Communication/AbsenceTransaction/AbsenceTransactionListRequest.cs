using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Communication.AbsenceTransaction
{
    public class AbsenceTransactionListRequest : FortnoxApiListedResourceRequest
    {
        public AbsenceTransactionListRequest(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
        }
    }
}

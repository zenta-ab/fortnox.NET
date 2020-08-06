using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Models.Offer
{
    public class EmailInformation
    {
        public object EmailAddressFrom { get; set; }
        public object EmailAddressTo { get; set; }
        public object EmailAddressCC { get; set; }
        public object EmailAddressBCC { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}

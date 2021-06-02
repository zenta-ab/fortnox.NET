using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxNET.Models.Offer
{
    public class EmailInformation
    {
        /// <summary>
        /// Reply to adress. Must be a valid e-mail address
        /// </summary>
        public object EmailAddressFrom { get; set; }

        /// <summary>
        /// Customer e-mail address
        /// </summary>
        public object EmailAddressTo { get; set; }

        /// <summary>
        /// Customer e-mail address copy	
        /// </summary>
        public object EmailAddressCC { get; set; }

        /// <summary>
        /// Customer e-mail address blind carbon copy	
        /// </summary>
        public object EmailAddressBCC { get; set; }

        /// <summary>
        /// Subject of e-mail
        /// </summary>
        public string EmailSubject { get; set; }

        /// <summary>
        /// Body of e-mail.
        /// </summary>
        public string EmailBody { get; set; }
    }
}

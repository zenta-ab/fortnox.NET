namespace FortnoxNET.Models.Invoice
{
    public class EmailInformation
    {
        /// <summary>
        /// Customer e-mail address – Blind carbon copy. Must be a valid e-mail address.
        /// </summary>
        public string EmailAddressBCC { get; set; }

        /// <summary>
        /// Customer e-mail address – Copy. Must be a valid e-mail address.
        /// </summary>
        public string EmailAddressCC { get; set; }

        /// <summary>
        /// Reply to adress. Must be a valid e-mail address
        /// </summary>
        public string EmailAddressFrom { get; set; }

        /// <summary>
        /// Customer e-mail address. Must be a valid e-mail address.
        /// </summary>
        public string EmailAddressTo { get; set; }

        /// <summary>
        /// Body of the e-mail.
        /// </summary>
        public string EmailBody { get; set; }

        /// <summary>
        /// Subject of the e-mail
        /// </summary>
        public string EmailSubject { get; set; }
    }
}
namespace FortnoxNET.Models.Invoice
{
    public class EDIInformation
    {
        /// <summary>
        /// Invoice address GLN for EDI
        /// </summary>
        public string EDIGlobalLocationNumber { get; set; }

        /// <summary>
        /// Delivery address GLN for EDI
        /// </summary>
        public string EDIGlobalLocationNumberDelivery { get; set; }

        /// <summary>
        /// Extra EDI Information
        /// </summary>
        public string EDIInvoiceExtra1 { get; set; }

        /// <summary>
        /// Extra EDI Information
        /// </summary>
        public string EDIInvoiceExtra2 { get; set; }

        /// <summary>
        /// Our electronic reference for EDI
        /// </summary>
        public string EDIOurElectronicReference { get; set; }

        /// <summary>
        /// Your electronic reference for EDI
        /// </summary>
        public string EDIYourElectronicReference { get; set; }

        /// <summary>
        /// Status of the send process of the invoice. Can have the following codes:
        /// 1 = Sent to Crediflow
        /// 2 = Checked by Crediflow
        /// 3 = Delivered electronically
        /// 4 = Delivered to printing service
        /// 5 = Delivered to Posten by print company
        /// 6 = Declined by Crediflow
        /// 7 = Declined by receiver
        /// </summary>
        public string EDIStatus { get; set; }
    }
}
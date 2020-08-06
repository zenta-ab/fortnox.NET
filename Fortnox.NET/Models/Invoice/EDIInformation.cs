namespace FortnoxNET.Models.Invoice
{
    public class EDIInformation
    {
        public string EDIGlobalLocationNumber { get; set; }
        public string EDIGlobalLocationNumberDelivery { get; set; }
        public string EDIInvoiceExtra1 { get; set; }
        public string EDIInvoiceExtra2 { get; set; }
        public string EDIOurElectronicReference { get; set; }
        public string EDIYourElectronicReference { get; set; }
    }
}
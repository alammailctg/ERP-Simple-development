namespace AenEnterprise.FrontEndMvc.Models
{
    public class CreatePaymentReceiptFormRequest
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Foreign Key to Invoice
        public int InvoiceId { get; set; }
    }
}

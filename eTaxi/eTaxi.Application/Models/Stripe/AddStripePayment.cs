namespace eTaxi.Application.Models.Stripe
{
    public class AddStripePayment
    {
        public string CustomerId { get; set; }
        public string ReceiptEmail { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public long Amount { get; set; }
    }
}

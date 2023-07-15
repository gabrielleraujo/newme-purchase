using Newtonsoft.Json;

namespace Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder.Received
{
    public class PaymentResolvedPurchaseOrderReceivedEvent
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("purchase_id")]
        public Guid PurchaseId { get; set; }

        [JsonProperty("buyer_id")]
        public Guid BuyerId { get; set; }

        [JsonProperty("payment_id")]
        public Guid PaymentId { get; set; }

        [JsonProperty("is_payment_authorized")]
        public bool IsPaymentAuthorized {get; set; }

        [JsonProperty("total_price")]
        public double TotalPrice {get; set; }
    }
}
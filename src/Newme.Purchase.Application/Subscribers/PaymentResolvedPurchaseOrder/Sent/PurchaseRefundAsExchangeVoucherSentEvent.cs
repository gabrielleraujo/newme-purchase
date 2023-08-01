using Newtonsoft.Json;

namespace Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder.Sent
{
    public class PurchaseRefundAsExchangeVoucherSentEvent
    {
        public PurchaseRefundAsExchangeVoucherSentEvent(
            Guid buyerId, 
            Guid purchaseId, 
            double totalPrice)
        {
            Id = Guid.NewGuid();
            BuyerId = buyerId;
            PurchaseId = purchaseId;
            TotalPrice = totalPrice;
        }

        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("purchase_id")]
        public Guid PurchaseId { get; private set; }

        [JsonProperty("buyer_id")]
        public Guid BuyerId { get; private set; }

        [JsonProperty("total_price")]
        public double TotalPrice {get; private set; }
    }
}
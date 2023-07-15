using Newtonsoft.Json;

namespace Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder.Sent
{
    public class PurchaseRefundAsExchangeVoucherSentEvent
    {
        public PurchaseRefundAsExchangeVoucherSentEvent(
            Guid buyerId, 
            Guid purchaseId, 
            string buyerName,
            string buyerEmail, 
            double totalPrice,
            double freightValue = 0.0)
        {
            Id = Guid.NewGuid();
            BuyerId = buyerId;
            PurchaseId = purchaseId;
            BuyerName = buyerName;
            BuyerEmail = buyerEmail;
            TotalPrice = totalPrice;
            FreightValue = freightValue;
        }

        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("purchase_id")]
        public Guid PurchaseId { get; private set; }

        [JsonProperty("buyer_id")]
        public Guid BuyerId { get; private set; }

        [JsonProperty("buyer_name")]
        public String BuyerName { get; private set; }

        [JsonProperty("buyer_email")]
        public String BuyerEmail { get; private set; }

        [JsonProperty("total_price")]
        public double TotalPrice {get; private set; }

        [JsonProperty("freight_value")]
        public double FreightValue {get; private set; }
    }
}
using Newtonsoft.Json;

namespace Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Sent
{
    public class CreatedPurchaseOrderItemSentEvent 
    {
        public CreatedPurchaseOrderItemSentEvent(int quantity, Guid productId)
        {
            Quantity = quantity;
            ProductId = productId;
        }

        [JsonIgnore]
        public static string Name => "purchase-order-payment-authorized";

        [JsonProperty("quantity")]
        public int Quantity { get; private set; }

        [JsonProperty("product_id")]
        public Guid ProductId { get; private set; }
    }
}

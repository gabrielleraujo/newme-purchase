using System.Text.Json.Serialization;

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
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }
    }
}

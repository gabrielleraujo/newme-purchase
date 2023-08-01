using Newtonsoft.Json;

namespace Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Sent
{
    public record CreatedPurchaseOrderSentEvent 
    {
        public CreatedPurchaseOrderSentEvent(Guid purchaseId, IList<CreatedPurchaseOrderItemSentEvent> items)
        {
            PurchaseId = purchaseId;
            Items = items;
        }

        [JsonProperty("purchase_id")]
        public Guid PurchaseId { get; private set; }

        [JsonProperty("terms")]
        public IList<CreatedPurchaseOrderItemSentEvent> Items { get; private set; }
    }
}

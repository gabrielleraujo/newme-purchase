namespace Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Sent
{
    public record CreatedPurchaseOrderSentEvent 
    {
        public CreatedPurchaseOrderSentEvent(Guid purchaseId, IList<CreatedPurchaseOrderItemSentEvent> items)
        {
            PurchaseId = purchaseId;
            Items = items;
        }

        public Guid PurchaseId { get; private set; }
        public IList<CreatedPurchaseOrderItemSentEvent> Items { get; private set; }
    }
}

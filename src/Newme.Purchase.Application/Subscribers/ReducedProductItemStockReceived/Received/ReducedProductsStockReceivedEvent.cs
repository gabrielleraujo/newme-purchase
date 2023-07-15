using Newtonsoft.Json;

namespace Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Received
{
    public class ReducedProductsStockReceivedEvent {
        
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("purchase_id")]
        public Guid PurchaseId { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("items")]
        public IList<ReducedProductItemStockReceivedEvent> Items{ get; set; }
    }
}
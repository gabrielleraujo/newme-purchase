using Newtonsoft.Json;

namespace Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Received
{
    public class ReducedProductItemStockReceivedEvent 
    {
        [JsonProperty("product_id")]
        public Guid ProductId { get; set; }

        [JsonProperty("quantity_achieved")]
        public int QuantityAchieved { get; set; }
    }
}

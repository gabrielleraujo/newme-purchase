using Newtonsoft.Json;

namespace Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Received
{
    public class ReducedProductItemStockReceivedEvent 
    {
        [JsonProperty("product_id")]
        public Guid ProductId { get; set; }

        [JsonProperty("quantity_required")]
        public int QuantityRequired { get; set; }

        [JsonProperty("quantity_achieved")]
        public int QuantityAchieved { get; set; }

        [JsonProperty("has_out_of_stock")]
        public bool HasOutOfStok { get; set; }

        [JsonProperty("is_empty_stock")]
        public bool IsEmptyStock { get; set; }
    }
}

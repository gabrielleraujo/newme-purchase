using System.Text.Json.Serialization;

namespace Newmw.Purchase.Application.ViewModels
{
    public class ReadPurchaseItemViewModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("purchase_id")]
        public Guid PurchaseId { get; set; }

        [JsonPropertyName("product_id")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("unit_price")]
        public double UnitPrice { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
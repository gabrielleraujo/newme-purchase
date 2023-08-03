using System.Text.Json.Serialization;

namespace Newmw.Purchase.Application.ViewModels
{
    public class ReadPurchaseViewModel
	{
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("buyer")]
        public ReadBuyerViewModel Buyer { get; set; }

        [JsonPropertyName("purchase_items")]
        public IList<ReadPurchaseItemViewModel> PurchaseItems { get; set; }

        [JsonPropertyName("address")]
        public ReadAddressViewModel Address { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("has_summary")]
        public bool HasSummary { get; set; }

        [JsonPropertyName("freight_value")]
        public double FreightValue { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
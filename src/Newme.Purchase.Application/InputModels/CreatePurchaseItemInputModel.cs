using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class CreatePurchaseItemInputModel
    {
        [JsonIgnore]
        public Guid Id  { get; set; }

        [JsonIgnore]
        public Guid PurchaseId { get; set; }

        [Required(ErrorMessage = "The product_id is Required")]
        [JsonPropertyName("product_id")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "The product is Required")]
        [JsonPropertyName("product")]
        public InputProductInputModel Product { get; set; }

        [Required(ErrorMessage = "The unit_price is Required")]
        [JsonPropertyName("unit_price")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "The quantity is Required")]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
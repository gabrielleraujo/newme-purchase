using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class CreatePurchaseInputModel
    {
        [Required(ErrorMessage = "The buyer_id is Required")]
        [JsonPropertyName("buyer_id")]
        public Guid BuyerId { get; set; }

        [Required(ErrorMessage = "The buyer is Required")]
        [JsonPropertyName("buyer")]
        public CreateBuyerInputModel Buyer { get; set; }

        [Required(ErrorMessage = "The purchase_items is Required")]
        [JsonPropertyName("purchase_items")]
        public IList<CreatePurchaseItemInputModel> PurchaseItems { get; set; }
 
        [Required(ErrorMessage = "The price is Required")]
        [JsonPropertyName("price")]
        public double Price {get; set; }

        [Required(ErrorMessage = "The freight_value is Required")]
        [JsonPropertyName("freight_value")]
        public double FreightValue { get; set; }

        [Required(ErrorMessage = "The has_discount_coupon is Required")]
        [JsonPropertyName("has_discount_coupon")]
        public bool HasDiscountCoupon { get; set; }

        [JsonPropertyName("discount_coupon_id")]
        public Guid DiscountCouponId { get; set; }

        [Required(ErrorMessage = "The address is Required")]
        [JsonPropertyName("address")]
        public CreateAddressInputModel Address { get; set; }
    }
}
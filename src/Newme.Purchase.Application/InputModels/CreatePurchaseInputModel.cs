using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class CreatePurchaseInputModel
    {
        [Required(ErrorMessage = "The buyer_id is Required")]
        [DisplayName("buyer_id")]
        public Guid BuyerId { get; set; }

        [Required(ErrorMessage = "The buyer is Required")]
        [DisplayName("buyer")]
        public CreateBuyerInputModel Buyer { get; set; }

        [Required(ErrorMessage = "The purchase_items is Required")]
        [DisplayName("purchase_items")]
        public IList<CreatePurchaseItemInputModel> PurchaseItems { get; set; }
 
        [Required(ErrorMessage = "The price is Required")]
        [DisplayName("price")]
        public double Price {get; set; }

        [Required(ErrorMessage = "The freight_value is Required")]
        [DisplayName("freight_value")]
        public double FreightValue { get; set; }

        [Required(ErrorMessage = "The has_discount_coupon is Required")]
        [DisplayName("has_discount_coupon")]
        public bool HasDiscountCoupon { get; set; }

        [DisplayName("discount_coupon_id")]
        public Guid DiscountCouponId { get; set; }

        [Required(ErrorMessage = "The address is Required")]
        [DisplayName("address")]
        public CreateAddressInputModel Address { get; set; }
    }
}
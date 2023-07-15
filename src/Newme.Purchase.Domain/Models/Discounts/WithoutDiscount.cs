using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Domain.Models.Discounts
{
    public class WithoutDiscount : Discount
    {
        public WithoutDiscount(double discountValue = 0) : base(discountValue)
        {
        }

        public override void Calculate(PurchaseOrder purchase, CurrentPrice currentPrice){ }
    }
}
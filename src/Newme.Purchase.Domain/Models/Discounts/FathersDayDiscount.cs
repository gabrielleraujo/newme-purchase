using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Domain.Models.Discounts
{
    public class FathersDayDiscount : Discount
    {
        public FathersDayDiscount(double discountValue = 0.30) : base(discountValue)
        {
        }

        public override void Calculate(PurchaseOrder purchase, CurrentPrice currentPrice)
        {
            if (purchase.Date.Month.Equals(8))
            {
                currentPrice.Price -= purchase.Price * DiscountValue;
            }

            Next.Calculate(purchase, currentPrice);
        }
    }
}
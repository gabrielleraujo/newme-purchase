using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Domain.Models.Discounts
{
    public abstract class Discount
    {
        protected Discount(double discountValue)
        {
            DiscountValue = discountValue;
        }

        public double DiscountValue { get; protected set; }
        public Discount Next { get; set; }

        public abstract void Calculate(PurchaseOrder purchase, CurrentPrice currentPrice);
    }
}
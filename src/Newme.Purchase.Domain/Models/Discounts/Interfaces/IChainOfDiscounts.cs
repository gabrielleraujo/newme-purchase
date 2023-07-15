using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Domain.Models.Discounts.Interfaces
{
    public interface IChainOfDiscounts
    {
        /// <summary>
        /// Returns the total price to be paid after all possible discounts have been applied to the purchase.
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns></returns>
        double CalculateDiscount(PurchaseOrder purchase);
    }
}
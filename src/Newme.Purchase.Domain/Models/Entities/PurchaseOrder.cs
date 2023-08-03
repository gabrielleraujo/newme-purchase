using Newme.Purchase.Domain.Models.Abstracts;
using Newme.Purchase.Domain.Models.Discounts.Interfaces;
using Newme.Purchase.Domain.Models.Enums;
using Newme.Purchase.Domain.Models.ValueObjects;

namespace Newme.Purchase.Domain.Models.Entities
{
    public class PurchaseOrder : Entity
    {
        public Guid BuyerId { get; private set; }

        public DateTime Date { get; private set; }
        public IList<PurchaseItem> PurchaseItems { get; private set; }
        public double Price { get; private set; }
        public bool HasSummary { get; private set; }

        public bool HasDiscountCoupon { get; private set; }
        public Guid DiscountCouponId { get; private set; }

        public double PurchseDiscountValue { get; private set; }

        public double FreightValue { get; private set; }
        public Address Address { get; private set; }
        public EPurchaseOrderStatus Status { get; private set; }

        private PurchaseOrder() { }
        public PurchaseOrder(
            Guid id,
            Guid buyerId, 
            Address address, 
            DateTime date, 
            double price, 
            bool HasDiscountCoupon,
            Guid discountCouponId,
            double freightValue,
            IList<PurchaseItem> purchaseItems) : base(id)
        {
            BuyerId = buyerId;
            Address = address;
            Date = date;
            Price = price;
            FreightValue = freightValue;
            PurchaseItems = purchaseItems;
            Status = EPurchaseOrderStatus.Initial;
        }

        private void UpdatePrice(double value)
        {
            if(value > 0)
            {
                Price = value;
            }
        }

        public double CalculateDiscont(IChainOfDiscounts chain)
        {
            var finalPrice = chain.CalculateDiscount(this);
            return finalPrice;
        }

        public void ApplyDiscont(IChainOfDiscounts chain)
        {
            var finalPrice = CalculateDiscont(chain);

            PurchseDiscountValue = Price - finalPrice;

            UpdatePrice(finalPrice);
        }

        public void AddFreight()
        {
            UpdatePrice(Price += this.FreightValue);
        }

        public void CalculateTotalValue(IChainOfDiscounts chain)
        {
            ApplyDiscont(chain);
            AddFreight();
        }

        public void UpdateStatus(EPurchaseOrderStatus status)
        {
            Status = status;
        }

        public double GetTotalRefund()
        {
            var itemsToRefund = PurchaseItems
                .Where(x => x.Status == EPurchaseOrderItemStatus.OutOfStock);

            var totalItemsToRefund = itemsToRefund.Sum(x => x.Refund);

            if (itemsToRefund.Count() == PurchaseItems.Count())
            {
                totalItemsToRefund += FreightValue;
            }
            return totalItemsToRefund;
        }

        public void ResolveStatus()
        {
            var itemsOutOfRangeCount = PurchaseItems.Where(
                x => x.Status == EPurchaseOrderItemStatus.OutOfStock).Count();

            var purchaseItemsCount = PurchaseItems.Count;
            if (itemsOutOfRangeCount == purchaseItemsCount)
            {
                Status = EPurchaseOrderStatus.OutOfStock;
                return;
            }
            if (itemsOutOfRangeCount > 0)
            {
                Status = EPurchaseOrderStatus.PartiallyApproved;
                return;
            }
            Status = EPurchaseOrderStatus.Approved;
        }
    }
}
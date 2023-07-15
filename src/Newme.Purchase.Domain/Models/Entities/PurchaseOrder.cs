using Newme.Purchase.Domain.Models.Abstracts;
using Newme.Purchase.Domain.Models.Discounts.Interfaces;
using Newme.Purchase.Domain.Models.Enums;
using Newme.Purchase.Domain.Models.ValueObjects;

namespace Newme.Purchase.Domain.Models.Entities
{
    public class PurchaseOrder : Entity
    {
        public Buyer Buyer { get; private set; }
        public Guid BuyerId { get; private set; }

        public DateTime Date { get; private set; }
        public IList<PurchaseItem> PurchaseItems { get; set; }
        public double Price { get; private set; }
        public bool HasSummary { get; private set; }

        public bool HasDiscountCoupon { get; private set; }
        public Guid DiscountCouponId { get; private set; }

        public double PurchseDiscountValue { get; private set; }

        public double FreightValue { get; private set; }
        public Address Address { get; private set; }
        public EPurchaseOrderState State { get; internal set; }        //ignore

        private PurchaseOrder() { }
        public PurchaseOrder(
            Guid id,
            Buyer buyer, 
            Guid buyerId, 
            Address address, 
            DateTime date, 
            double price, 
            bool HasDiscountCoupon,
            Guid discountCouponId,
            double freightValue,
            IList<PurchaseItem> purchaseItems) : base(id)
        {
            Buyer = buyer;
            BuyerId = buyerId;
            Address = address;
            Date = date;
            Price = price;
            FreightValue = freightValue;
            PurchaseItems = purchaseItems;
            State = EPurchaseOrderState.Initial;
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

        public void UpdateState(EPurchaseOrderState state)
        {
            State = state;
        }
    }
}
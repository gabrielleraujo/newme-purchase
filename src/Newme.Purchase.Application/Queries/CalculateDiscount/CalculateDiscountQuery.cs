using MediatR;
using Newmw.Purchase.Application.InputModels;

namespace Newme.Purchase.Application.Queries.CalculateDiscount
{
    public class CalculateDiscountQuery : IRequest<double>
    {
        public CalculateDiscountQuery(
            CreateBuyerInputModel buyer, 
            IList<CreatePurchaseItemInputModel> purchaseItems, 
            double price, 
            double freightValue, 
            bool hasDiscountCoupon, 
            Guid discountCouponId, 
            CreateAddressInputModel address)
        {
            Buyer = buyer;
            PurchaseItems = purchaseItems;
            Price = price;
            FreightValue = freightValue;
            HasDiscountCoupon = hasDiscountCoupon;
            DiscountCouponId = discountCouponId;
            Address = address;
        }

        public CreateBuyerInputModel Buyer { get; private set; }
        public IList<CreatePurchaseItemInputModel> PurchaseItems { get; private set; }
        public double Price {get; private set; }
        public double FreightValue { get; private set; }
        public bool HasDiscountCoupon { get; private set; }
        public Guid DiscountCouponId { get; private set; }
        public CreateAddressInputModel Address { get; private set; }
    }
}
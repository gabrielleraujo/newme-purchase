using FluentValidation.Results;
using MediatR;
using Newme.Purchase.Application.Validations;
using Newmw.Purchase.Application.InputModels;

namespace Newme.Purchase.Application.Commands.CreatePurchase
{
    public class CreatePurchaseCommand : Command, IRequest<ValidationResult>
    {
        public CreatePurchaseCommand(
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

            Setup(
                purchaseId: Guid.NewGuid(), 
                buyerId: Buyer.Id
            );
        }

        public CreateBuyerInputModel Buyer { get; private set; }
        public IList<CreatePurchaseItemInputModel> PurchaseItems { get; private set; }
        public double Price {get; private set; }
        public double FreightValue { get; private set; }
        public bool HasDiscountCoupon { get; private set; }
        public Guid DiscountCouponId { get; private set; }
        public CreateAddressInputModel Address { get; private set; }

        public override bool IsValid() 
        {
            ValidationResult = new CreatePurchaseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        private void Setup(Guid purchaseId, Guid buyerId)
        {
            Buyer.Id = buyerId;

            foreach(var item in PurchaseItems)
            {
                item.Id = Guid.NewGuid();
                item.PurchaseId = purchaseId;
            }
        }
    }
}

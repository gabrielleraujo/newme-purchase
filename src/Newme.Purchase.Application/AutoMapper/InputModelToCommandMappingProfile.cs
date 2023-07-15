using AutoMapper;
using Newme.Purchase.Application.Commands.CreatePurchase;
using Newme.Purchase.Application.Queries.CalculateDiscount;
using Newmw.Purchase.Application.InputModels;

namespace Newme.Purchase.Application.AutoMapper
{
    public class InputModelToCommandMappingProfile : Profile
    {
        public InputModelToCommandMappingProfile()
        {
            CreateMap<CreatePurchaseInputModel, CreatePurchaseCommand>()
                .ConstructUsing(x => new CreatePurchaseCommand(
                    x.Buyer,
                    x.PurchaseItems,
                    x.Price,
                    x.FreightValue,
                    x.HasDiscountCoupon,
                    x.DiscountCouponId,
                    x.Address
                ));

            CreateMap<CreatePurchaseInputModel, CalculateDiscountQuery>()
                .ConstructUsing(x => new CalculateDiscountQuery(
                    x.Buyer,
                    x.PurchaseItems,
                    x.Price,
                    x.FreightValue,
                    x.HasDiscountCoupon,
                    x.DiscountCouponId,
                    x.Address
                ));
        }
    }
}

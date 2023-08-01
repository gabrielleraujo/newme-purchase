using AutoMapper;
using MediatR;
using Newme.Purchase.Domain.Models.Discounts.Interfaces;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Models.ValueObjects;
using Newme.Purchase.Application.Consulting.Repositories;

namespace Newme.Purchase.Application.Queries.CalculateDiscount
{
    public class CalculateDiscountQueryHandler : IRequestHandler<CalculateDiscountQuery, double>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseQueryRepository _repository;
        private readonly IChainOfDiscounts _chainOfDiscounts;

        public CalculateDiscountQueryHandler(
            IMapper mapper,
            IPurchaseQueryRepository repository,
            IChainOfDiscounts chainOfDiscounts)
        {
            _mapper = mapper;
            _repository = repository;
            _chainOfDiscounts = chainOfDiscounts;
        }

        public async Task<double> Handle(CalculateDiscountQuery request, CancellationToken cancellationToken)
        {
            var purchaseOrder = new PurchaseOrder(
                id: Guid.NewGuid(),
                buyer: _mapper.Map<Buyer>(request.Buyer),
                buyerId: request.Buyer.Id,
                address: _mapper.Map<Address>(request.Address),
                date: DateTime.Now,
                price: request.Price,
                HasDiscountCoupon: request.HasDiscountCoupon,
                discountCouponId: request.DiscountCouponId,
                freightValue: request.FreightValue,
                purchaseItems: _mapper.Map<IList<PurchaseItem>>(request.PurchaseItems)
            );

            return purchaseOrder.CalculateDiscont(_chainOfDiscounts);
        }
    }
}

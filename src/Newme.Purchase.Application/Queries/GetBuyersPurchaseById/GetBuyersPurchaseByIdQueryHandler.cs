using AutoMapper;
using MediatR;
using Newme.Purchase.Infrastructure.Consulting.Repositories;
using Newmw.Purchase.Application.ViewModels;

namespace Newme.Purchase.Application.Queries.GetBuyersPurchaseById
{
    public class GetBuyersPurchaseByIdQueryHandler : IRequestHandler<GetBuyersPurchaseByIdQuery, ReadPurchaseViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseQueryRepository _repository;

        public GetBuyersPurchaseByIdQueryHandler(
            IMapper mapper,
            IPurchaseQueryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReadPurchaseViewModel> Handle(GetBuyersPurchaseByIdQuery request, CancellationToken cancellationToken)
        {
            var purchase = await _repository.GetByIdAsync(request.PurchaseId);

            if (purchase == null) return null;

            var purchaseViewModel = _mapper.Map<ReadPurchaseViewModel>(purchase);

            return purchaseViewModel;
        }
    }
}

using AutoMapper;
using MediatR;
using Newme.Purchase.Infrastructure.Consulting.Repositories;
using Newmw.Purchase.Application.ViewModels;

namespace Newme.Purchase.Application.Queries.GetAllBuyersPurchases
{
    public class GetAllBuyersPurchasesQueryHandler : IRequestHandler<GetAllBuyersPurchasesQuery, IEnumerable<ReadPurchaseViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseQueryRepository _repository;

        public GetAllBuyersPurchasesQueryHandler(
            IMapper mapper,
            IPurchaseQueryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ReadPurchaseViewModel>> Handle(GetAllBuyersPurchasesQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _repository.GetAllBuyersPurchase(request.BuyerId);

            if (purchases == null) return null;

            var purchasesViewModel = _mapper.Map<IEnumerable<ReadPurchaseViewModel>>(purchases);

            return purchasesViewModel;
        }
    }
}

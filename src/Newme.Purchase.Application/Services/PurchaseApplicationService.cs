using FluentValidation.Results;
using Newmw.Purchase.Application.InputModels;
using Newmw.Purchase.Application.ViewModels;
using AutoMapper;
using MediatR;
using Newme.Purchase.Application.Queries.CalculateDiscount;
using Newme.Purchase.Application.Commands.CreatePurchase;
using Newme.Purchase.Application.Queries.GetAllBuyersPurchases;
using Newme.Purchase.Application.Queries.GetBuyersPurchaseById;

namespace Newme.Purchase.Application.Services
{
    public class PurchaseApplicationService : IPurchaseApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PurchaseApplicationService(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ReadPurchaseViewModel>> GetAll(Guid buyerId)
        {
            var command = new GetAllBuyersPurchasesQuery(buyerId);
            return await _mediator.Send(command);
        }

        public async Task<ReadPurchaseViewModel> GetById(Guid purchaseId)
        {
            var command = new GetBuyersPurchaseByIdQuery(purchaseId);
            return await _mediator.Send(command);
        }

        public async Task<double> CalculateDiscount(CreatePurchaseInputModel inputModel)
        {
            var command = _mapper.Map<CalculateDiscountQuery>(inputModel);
            return await _mediator.Send(command);
        }

        public async Task<ValidationResult> Register(CreatePurchaseInputModel inputModel)
        {
            var command = _mapper.Map<CreatePurchaseCommand>(inputModel);
            return await _mediator.Send(command);
        }
    }
}

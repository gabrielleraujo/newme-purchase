using MediatR;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Repositories;
using AutoMapper;
using Newme.Purchase.Domain.Models.ValueObjects;
using Newme.Purchase.Domain.Models.Discounts.Interfaces;
using FluentValidation.Results;
using Newme.Purchase.Application.Events;
using Newme.Purchase.Infrastructure.Messaging;
using Microsoft.Extensions.Logging;
using Newme.Purchase.Domain.Models.Enums;
using Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Sent;

namespace Newme.Purchase.Application.Commands.CreatePurchase
{
    public class CreatePurchaseCommandHandler : 
        CommandHandler<CreatePurchaseCommandHandler>,
        IRequestHandler<CreatePurchaseCommand, ValidationResult>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPurchaseCommandRepository _repositoryCommand;
        private readonly IChainOfDiscounts _chainOfDiscounts;
        private readonly IMessageBusServer _messageBus;

        public CreatePurchaseCommandHandler(
            ILogger<CreatePurchaseCommandHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IPurchaseCommandRepository repository,
            IChainOfDiscounts chainOfDiscounts,
            IMessageBusServer messageBus) : base(logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repositoryCommand = repository;
            _chainOfDiscounts = chainOfDiscounts;
            _messageBus = messageBus;
        }
        
        public async Task<ValidationResult> Handle(CreatePurchaseCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(CreatePurchaseCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var purchaseOrder = new PurchaseOrder(
                id: command.PurchaseItems.FirstOrDefault()!.PurchaseId,
                buyer: _mapper.Map<Buyer>(command.Buyer),
                buyerId: command.Buyer.Id,
                address: _mapper.Map<Address>(command.Address),
                date: DateTime.Now,
                price: command.Price,
                HasDiscountCoupon: command.HasDiscountCoupon,
                discountCouponId: command.DiscountCouponId,
                freightValue: command.FreightValue,
                purchaseItems: _mapper.Map<IList<PurchaseItem>>(command.PurchaseItems)
            );

            purchaseOrder.ApplyDiscont(_chainOfDiscounts);
            purchaseOrder.AddFreight();
            purchaseOrder.UpdateState(EPurchaseOrderState.PaymentValidation);

            await RegisterPurchase(command, purchaseOrder);

            var isCommitSuccess = await _repositoryCommand.CommitAsync();

            if (isCommitSuccess)
            {
                await SendDomainEvent(purchaseOrder).ConfigureAwait(false);
            }

            _logger.LogInformation($"{nameof(CreatePurchaseCommandHandler)} successfully completed");

            return ValidationResult;
        }

        private async Task RegisterPurchase(CreatePurchaseCommand command, PurchaseOrder purchaseOrder)
        {
            var buyer = await _repositoryCommand.FindByAsync<Buyer>(x => x.Id == purchaseOrder.BuyerId);
            if (buyer == null) await _repositoryCommand.AddBuyerAsync(purchaseOrder.Buyer);

            var products = _mapper.Map<IList<Product>>(command.PurchaseItems.Select(x => x.Product).ToList());
            var productsNotYetRegistered = _repositoryCommand.GetItemsNotFound<Product>(products);

            await _repositoryCommand.AddRangeProductsAsync(productsNotYetRegistered);
            await _repositoryCommand.AddAsync(purchaseOrder);
        }

        private async Task SendDomainEvent(PurchaseOrder purchaseOrder)
        {
            var createdPurchaseOrderEvent = new CreatedPurchaseOrderEvent(
                id: Guid.NewGuid(),
                purchaseOrder: purchaseOrder);
            await _mediator.Publish(createdPurchaseOrderEvent).ConfigureAwait(false);
        }
    }
}

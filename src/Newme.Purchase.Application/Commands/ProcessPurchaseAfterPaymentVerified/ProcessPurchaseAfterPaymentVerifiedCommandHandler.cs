using MediatR;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Repositories;
using AutoMapper;
using Newme.Purchase.Domain.Models.Discounts.Interfaces;
using FluentValidation.Results;
using Newme.Purchase.Infrastructure.Messaging;
using Microsoft.Extensions.Logging;
using Newme.Purchase.Application.Events.ProcessedPurchase;
using Newme.Purchase.Domain.Models.Enums;
using Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Sent;

namespace Newme.Purchase.Application.Commands.ProcessPurchaseAfterCatalogVerified
{
    public class ProcessPurchaseAfterPaymentVerifiedCommandHandler : 
        CommandHandler<ProcessPurchaseAfterPaymentVerifiedCommandHandler>,
        IRequestHandler<ProcessPurchaseAfterPaymentVerifiedCommand, ValidationResult>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPurchaseCommandRepository _commandRepository;
        private readonly IChainOfDiscounts _chainOfDiscounts;
        private readonly IMessageBusServer _messageBus;

        public ProcessPurchaseAfterPaymentVerifiedCommandHandler(
            ILogger<ProcessPurchaseAfterPaymentVerifiedCommandHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IPurchaseCommandRepository repository,
            IChainOfDiscounts chainOfDiscounts,
            IMessageBusServer messageBus) : base(logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _commandRepository = repository;
            _chainOfDiscounts = chainOfDiscounts;
            _messageBus = messageBus;
        }
        
        public async Task<ValidationResult> Handle(ProcessPurchaseAfterPaymentVerifiedCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ProcessPurchaseAfterPaymentVerifiedCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var purchaseOrder = await _commandRepository.FindIncludingByAsync(x => x.Id == command.Event.PurchaseId);

            if (purchaseOrder == null)
            {
                AddError("Purchase order not found.");
                return ValidationResult;
            }
            
            if (command.Event.IsPaymentAuthorized)
            {
                await RunPurchaseApproved(purchaseOrder).ConfigureAwait(false);
            }
            else
            {
                await RunPurchaseRejected(purchaseOrder).ConfigureAwait(false);
            }

            _logger.LogInformation($"{nameof(ProcessPurchaseAfterPaymentVerifiedCommandHandler)} successfully completed");

            return ValidationResult;
        }

        private async Task RunPurchaseRejected(PurchaseOrder purchaseOrder)
        {
            var isCommitSuccess = await _commandRepository.UpdateStateAsync(
                purchaseOrder.Id,
                EPurchaseOrderState.PaymentUnauthorized);

            if (isCommitSuccess)
            {
                await SendDomainEvent(purchaseOrder).ConfigureAwait(false);
            }
        }

        private async Task RunPurchaseApproved(PurchaseOrder purchaseOrder)
        {
            var isCommitSuccess = await _commandRepository.UpdateStateAsync(
                purchaseOrder.Id,
                EPurchaseOrderState.PaymentAuthorized);

            if (isCommitSuccess)
            {
                await SendDomainEvent(purchaseOrder).ConfigureAwait(false);
                SendExternalEventToMessageBus(purchaseOrder);
            }
        }
        
        private void SendExternalEventToMessageBus(PurchaseOrder purchaseOrder)
        {
            var setEvent = new CreatedPurchaseOrderSentEvent(
                purchaseId: purchaseOrder.Id,
                items: purchaseOrder.PurchaseItems.Select(x =>
                    new CreatedPurchaseOrderItemSentEvent(
                        productId: x.ProductId,
                        quantity: x.Quantity)).ToList()
            );

            _messageBus.Publish(setEvent, CreatedPurchaseOrderItemSentEvent.Name);
        }

        private async Task SendDomainEvent(PurchaseOrder purchaseOrder)
        {
            var processedPurchaseOrderEvent = new ProcessedPurchaseEvent(
                purchaseOrder: purchaseOrder,
                detail: "processed purchase after payment verified.");

            await _mediator.Publish(processedPurchaseOrderEvent).ConfigureAwait(false);
        }
    }
}

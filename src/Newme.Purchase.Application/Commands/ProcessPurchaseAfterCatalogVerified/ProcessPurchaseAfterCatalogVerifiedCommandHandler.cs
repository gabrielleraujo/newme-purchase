using MediatR;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Repositories;
using AutoMapper;
using Newme.Purchase.Domain.Models.Discounts.Interfaces;
using FluentValidation.Results;
using Newme.Purchase.Domain.Messaging;
using Microsoft.Extensions.Logging;
using Newme.Purchase.Application.Events.ProcessedPurchase;
using Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder.Sent;
using Newme.Purchase.Domain.Extensions;

namespace Newme.Purchase.Application.Commands.ProcessPurchaseAfterCatalogVerified
{
    public class ProcessPurchaseAfterCatalogVerifiedCommandHandler : 
        CommandHandler<ProcessPurchaseAfterCatalogVerifiedCommandHandler>,
        IRequestHandler<ProcessPurchaseAfterCatalogVerifiedCommand, ValidationResult>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPurchaseCommandRepository _commandRepository;
        private readonly IChainOfDiscounts _chainOfDiscounts;
        private readonly IMessageBusServer _messageBus;

        public ProcessPurchaseAfterCatalogVerifiedCommandHandler(
            ILogger<ProcessPurchaseAfterCatalogVerifiedCommandHandler> logger,
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
        
        public async Task<ValidationResult> Handle(ProcessPurchaseAfterCatalogVerifiedCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ProcessPurchaseAfterCatalogVerifiedCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            if (command.Event.Success == false)
            {
                AddError($"Error in catalog verified step for purchase id {command.Event.PurchaseId}.");
                return command.ValidationResult;
            }

            var purchaseOrder = await _commandRepository.FindByAsync<PurchaseOrder>(x => x.Id == command.Event.PurchaseId);
            var purchaseItems = await _commandRepository.GetByAsync<PurchaseItem>(x => x.PurchaseOrderId == command.Event.PurchaseId);

            if (purchaseItems == null)
            {
                AddError("Purchase items order not found.");
                return ValidationResult;
            }

            if (purchaseOrder == null)
            {
                AddError("Purchase order not found.");
                return ValidationResult;
            }

            await Parallel.ForEachAsync(
                source: purchaseItems,
                cancellationToken: cancellationToken,
                body: async (purchaseItem, stoppingToken) => await ResolvePurchaseItemStatus(
                    purchaseItem, command)).ConfigureAwait(false);

            // Resolver status da compra
            purchaseOrder.ResolveStatus();
            await _commandRepository.UpdateStatusAsync(purchaseOrder);

            await SendDomainEvent(purchaseOrder).ConfigureAwait(false);

            var totalRefund = purchaseOrder.GetTotalRefund();
            if (totalRefund > 0)
            {
                SendExternalEventToMessageBus(purchaseOrder, totalRefund);
            }

            _logger.LogInformation($"{nameof(ProcessPurchaseAfterCatalogVerifiedCommandHandler)} successfully completed");

            return ValidationResult;
        }

        private async Task<ValidationResult> ResolvePurchaseItemStatus(
            PurchaseItem purchaseItem, 
            ProcessPurchaseAfterCatalogVerifiedCommand command)
        {
            var commandItem = command.Event.Items.FirstOrDefault(x => x.ProductId == purchaseItem.ProductId);
            var quantityAchieved = commandItem!.QuantityAchieved;
            
            purchaseItem.ApplyRefund(quantityAchieved);
            purchaseItem.UpdateStatus(quantityAchieved);

            await _commandRepository.UpdateItemStatusAsync(purchaseItem);
            return ValidationResult;
        }

        private async Task SendDomainEvent(PurchaseOrder purchaseOrder)
        {
            var processedPurchaseOrderEvent = new ProcessedPurchaseEvent(
                purchaseOrder: purchaseOrder,
                detail: "processed purchase after catalog verified.");

            await _mediator.Publish(processedPurchaseOrderEvent).ConfigureAwait(false);
        }

        private void SendExternalEventToMessageBus(PurchaseOrder purchaseOrder, double totalRefund)
        {
            var sentEvent = new PurchaseRefundAsExchangeVoucherSentEvent(
                buyerId: purchaseOrder.BuyerId,
                purchaseId: purchaseOrder.Id,
                totalPrice: purchaseOrder.GetTotalRefund()
            );
            _logger.LogInformation("Message purchase order item is rejected by item out of stock, event is sending with purchase id: {purchaseId}.\npurchase order item status is: {state}.",
                purchaseOrder.Id, purchaseOrder.Status.GetEnumDescription());

            _messageBus.Publish(sentEvent, "purchase-refund-as-exchange-voucher");
        }
    }
}

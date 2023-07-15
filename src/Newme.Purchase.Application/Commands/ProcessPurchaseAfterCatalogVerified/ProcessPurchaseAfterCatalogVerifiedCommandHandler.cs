using MediatR;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Repositories;
using AutoMapper;
using Newme.Purchase.Domain.Models.Discounts.Interfaces;
using FluentValidation.Results;
using Newme.Purchase.Infrastructure.Messaging;
using Microsoft.Extensions.Logging;
using Newme.Purchase.Application.Events.ProcessedPurchase;
using Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder.Sent;
using Newme.Purchase.Domain.Models.Enums;
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

            var vouncherValue = 0.0;
            await Parallel.ForEachAsync(
                source: purchaseItems, 
                cancellationToken: cancellationToken, 
                body: async (purchaseItem, stoppingToken) => await ResolvePurchaseItemState(
                    purchaseItem, purchaseOrder, command, vouncherValue)).ConfigureAwait(true);

            _logger.LogInformation($"{nameof(ProcessPurchaseAfterCatalogVerifiedCommandHandler)} successfully completed");

            return ValidationResult;
        }


        private async Task<ValidationResult> ResolvePurchaseItemState(
            PurchaseItem purchaseItem, 
            PurchaseOrder purchaseOrder, 
            ProcessPurchaseAfterCatalogVerifiedCommand command,
            double totalVouncher)
        {
            var commandItem = command.Event.Items.FirstOrDefault(x => x.ProductId == purchaseItem.ProductId);
            
            if (commandItem!.IsEmptyStock)
            {
                return await ResolveIsEmptyStock(purchaseOrder, purchaseItem);
            }

            var vouncherItem = purchaseItem.CalculateVouncher(commandItem!.QuantityAchieved);
            totalVouncher += vouncherItem;

            if (vouncherItem > 0)
            {
                return await ResolveIsNotEmptyStockButHasVouncherValue(purchaseOrder, vouncherItem);
            }
            
            return await ResolveAllItemsAccepted(purchaseOrder);
        }

        private async Task<ValidationResult> ResolveIsEmptyStock(
            PurchaseOrder purchaseOrder,
            PurchaseItem purchaseItem)
        {
            var isCommitSuccess = await _commandRepository.UpdateStateAsync(purchaseOrder.Id, EPurchaseOrderState.OutOfStock);

            if (isCommitSuccess)
            {
                await SendDomainEvent(purchaseOrder).ConfigureAwait(false);

                var sentEvent = new PurchaseRefundAsExchangeVoucherSentEvent(
                    buyerId: purchaseOrder.Buyer.Id,
                    purchaseId: purchaseOrder.Id,
                    buyerName: purchaseOrder.Buyer.Name,
                    buyerEmail: purchaseOrder.Buyer.Email,
                    totalPrice: purchaseItem.CalculateRefund(),
                    freightValue: purchaseOrder.FreightValue
                );
                _logger.LogInformation("Message purchase order reject by item out of stock, event is sending with purchase id: {purchaseId}.\npurchase order state is: {state}.",
                    purchaseOrder.Id, 
                    EPurchaseOrderState.OutOfStock.GetEnumDescription());

                _messageBus.Publish(sentEvent, "purchase-refund-as-exchange-voucher");
                // Enviar email de que a compra foi rejeitada por falta de estoque, nesse caso o frete tbm é reembolsado pq n terá envio algum.
            }

            return ValidationResult;
        }

        private async Task<ValidationResult> ResolveIsNotEmptyStockButHasVouncherValue(
            PurchaseOrder purchaseOrder, 
            double vouncherValue)
        {
            var isCommitSuccess = await _commandRepository.UpdateStateAsync(purchaseOrder.Id, EPurchaseOrderState.PartiallyApproved);

            if (isCommitSuccess)
            {
                await SendDomainEvent(purchaseOrder).ConfigureAwait(false);
                
                var sentEvent = new PurchaseRefundAsExchangeVoucherSentEvent(
                    buyerId: purchaseOrder.BuyerId,
                    purchaseId: purchaseOrder.Id,
                    buyerName: purchaseOrder.Buyer.Name,
                    buyerEmail: purchaseOrder.Buyer.Email,
                    totalPrice: vouncherValue
                );
                _logger.LogInformation("Message some itens in purchase order is rejected by item out of stock, event is sending with purchase id: {purchaseId}.\npurchase order state is: {state}.",
                    purchaseOrder.Id, 
                    EPurchaseOrderState.PartiallyApproved.GetEnumDescription());

                _messageBus.Publish(sentEvent, "purchase-refund-as-exchange-voucher");
                // Enviar email de que foi aprovado com alguns itens rejeitados por falta de estoque e que tera vale compra no valor dos itens que foram rejeitados or falta de estoque.
            }

            return ValidationResult;
        }

        private async Task<ValidationResult> ResolveAllItemsAccepted(
            PurchaseOrder purchaseOrder)
        {
            var isCommitSuccess = await _commandRepository.UpdateStateAsync(purchaseOrder.Id, EPurchaseOrderState.Approved);

            if (isCommitSuccess)
            {
                _logger.LogInformation("Message all itens in purchase order is accepted, event is sending with purchase id: {purchaseId}.\npurchase order state is: {state}.",
                    purchaseOrder.Id, 
                    EPurchaseOrderState.Approved.GetEnumDescription());

                await SendDomainEvent(purchaseOrder).ConfigureAwait(false);
                // Enviar email de que foi aprovada.
            }

            return ValidationResult;
        }

        private async Task SendDomainEvent(PurchaseOrder purchaseOrder)
        {
            var processedPurchaseOrderEvent = new ProcessedPurchaseEvent(
                purchaseOrder: purchaseOrder,
                detail: "processed purchase after catalog verified.");

            await _mediator.Publish(processedPurchaseOrderEvent).ConfigureAwait(false);
        }
    }
}

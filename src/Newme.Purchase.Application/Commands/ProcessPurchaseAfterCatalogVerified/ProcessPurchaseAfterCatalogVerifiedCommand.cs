using FluentValidation.Results;
using MediatR;
using Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived.Received;

namespace Newme.Purchase.Application.Commands.ProcessPurchaseAfterCatalogVerified
{
    public class ProcessPurchaseAfterCatalogVerifiedCommand : Command, IRequest<ValidationResult>
    {
        public ProcessPurchaseAfterCatalogVerifiedCommand(
            ReducedProductsStockReceivedEvent @event)
        {
            Id = Guid.NewGuid();
            Event = @event;
        }

        public Guid Id { get; private set; }
        public ReducedProductsStockReceivedEvent Event { get; private set; }
    }
}

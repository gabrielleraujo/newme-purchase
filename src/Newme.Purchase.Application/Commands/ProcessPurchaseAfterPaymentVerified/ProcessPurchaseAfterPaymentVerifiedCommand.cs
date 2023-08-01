using FluentValidation.Results;
using MediatR;
using Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder.Received;

namespace Newme.Purchase.Application.Commands.ProcessPurchaseAfterCatalogVerified
{
    public class ProcessPurchaseAfterPaymentVerifiedCommand : Command, IRequest<ValidationResult>
    {
        public ProcessPurchaseAfterPaymentVerifiedCommand(
            PaymentResolvedPurchaseOrderReceivedEvent @event)
        {
            Event = @event;
        }

        public PaymentResolvedPurchaseOrderReceivedEvent Event { get; private set; }
    }
}

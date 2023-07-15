using MediatR;
using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Application.Events.ProcessedPurchase
{
    public class ProcessedPurchaseEvent : INotification
    {
        public Guid Id { get; }
        public PurchaseOrder PurchaseOrder { get; }
        public string Detail { get; }

        public ProcessedPurchaseEvent(PurchaseOrder purchaseOrder, string detail)
        {
            Id = Guid.NewGuid();
            PurchaseOrder = purchaseOrder;
            Detail = detail;
        }
    }
}
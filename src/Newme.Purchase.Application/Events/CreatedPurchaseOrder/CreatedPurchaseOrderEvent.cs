using MediatR;
using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Application.Events
{
    public class CreatedPurchaseOrderEvent : INotification
    {
        public CreatedPurchaseOrderEvent(
            Guid id, 
            PurchaseOrder purchaseOrder)
        {
            Id = id;
            PurchaseOrder = purchaseOrder;
        }

        public Guid Id { get; private set; }
        public PurchaseOrder PurchaseOrder { get; private set; }
    }
}

using MediatR;
using Newme.Purchase.Domain.Models.Entities;
using Newmw.Purchase.Application.InputModels;

namespace Newme.Purchase.Application.Events
{
    public class CreatedPurchaseOrderEvent : INotification
    {
        public CreatedPurchaseOrderEvent(
            Guid id, 
            PurchaseOrder purchaseOrder,
            CreateBuyerInputModel buyer,
            IEnumerable<InputProductInputModel> products)
        {
            Id = id;
            PurchaseOrder = purchaseOrder;
            Buyer = buyer;
            Products = products;
        }

        public Guid Id { get; private set; }
        public PurchaseOrder PurchaseOrder { get; private set; }
        public CreateBuyerInputModel Buyer { get; private set; }
        public IEnumerable<InputProductInputModel> Products { get; private set; }
    }
}

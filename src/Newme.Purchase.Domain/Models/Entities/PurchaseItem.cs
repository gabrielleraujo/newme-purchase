using Newme.Purchase.Domain.Models.Abstracts;
using Newme.Purchase.Domain.Models.Enums;

namespace Newme.Purchase.Domain.Models.Entities
{
    public class PurchaseItem : Entity
    {
        private PurchaseItem() { }
        public PurchaseItem(
            Guid id, 
            Guid purchaseOrderId,
            Guid productId, 
            double unitPrice, 
            int quantity) : base(id)
        {
            PurchaseOrderId = purchaseOrderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Status = EPurchaseOrderItemStatus.Approved;
        }

        public Guid PurchaseOrderId { get; set; }
        public Guid ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public EPurchaseOrderItemStatus Status { get; internal set; }
        public double Refund { get; internal set; }

        public void ApplyRefund(int quantityAchieved)
        {
            Refund = UnitPrice * (Quantity - quantityAchieved);
        }

        public void UpdateStatus(int quantityAchieved)
        {
            if (quantityAchieved == 0)
            {
                Status = EPurchaseOrderItemStatus.OutOfStock;
                return;
            }
            if (quantityAchieved < Quantity && quantityAchieved > 0)
            {
                Status = EPurchaseOrderItemStatus.PartiallyApproved;
                return;
            }
            Status = EPurchaseOrderItemStatus.Approved;
        }
    }
}

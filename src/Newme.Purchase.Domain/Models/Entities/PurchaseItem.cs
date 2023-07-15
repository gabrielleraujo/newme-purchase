using Newme.Purchase.Domain.Models.Abstracts;

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
        }

        public Guid PurchaseOrderId { get; set; }
        public Guid ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        public double CalculateVouncher(int quantityAchieved)
        {
            return UnitPrice * (Quantity - quantityAchieved);
        }

        public double CalculateRefund()
        {
            return UnitPrice * Quantity;
        }
    }
}

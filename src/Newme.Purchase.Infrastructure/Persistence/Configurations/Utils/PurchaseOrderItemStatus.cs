using Newme.Purchase.Domain.Models.Enums;

namespace Newme.Purchase.Infrastructure.Configurations.Utils
{
    public class PurchaseOrderItemStatus : StatusBase<EPurchaseOrderItemStatus>
    {
        public static List<PurchaseOrderItemStatus> Data => new List<PurchaseOrderItemStatus>()
        {
            new(EPurchaseOrderItemStatus.Initial),
            new(EPurchaseOrderItemStatus.OutOfStock),
            new(EPurchaseOrderItemStatus.PartiallyApproved),
            new(EPurchaseOrderItemStatus.Approved)
        };
        
        public PurchaseOrderItemStatus(EPurchaseOrderItemStatus status) : base(status) {}
    }
}

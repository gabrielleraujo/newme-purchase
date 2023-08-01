using Newme.Purchase.Domain.Models.Enums;

namespace Newme.Purchase.Infrastructure.Configurations.Utils
{
    public class PurchaseOrderStatus : StatusBase<EPurchaseOrderStatus>
    {
        public static List<PurchaseOrderStatus> Data => new List<PurchaseOrderStatus>()
        {
            new(EPurchaseOrderStatus.Initial),
            new(EPurchaseOrderStatus.PaymentValidation),
            new(EPurchaseOrderStatus.PaymentAuthorized),
            new(EPurchaseOrderStatus.PaymentUnauthorized),
            new(EPurchaseOrderStatus.OutOfStock),
            new(EPurchaseOrderStatus.PartiallyApproved),
            new(EPurchaseOrderStatus.Approved)
        };

        public PurchaseOrderStatus(EPurchaseOrderStatus status) : base(status) {}
    }
}

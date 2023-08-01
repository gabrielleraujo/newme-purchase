using System.ComponentModel;

namespace Newme.Purchase.Domain.Models.Enums
{
    public enum EPurchaseOrderItemStatus
    {
        [Description("item de compra criado")]
        Initial = 0,

        [Description("item de compra aprovado")]
        Approved = 1,

        [Description("item de compra não aprovado porque o produto estava fora de estoque")]
        OutOfStock = 2,

        [Description("item de compra parcialmente aprovado")]
        PartiallyApproved = 3
    }
}

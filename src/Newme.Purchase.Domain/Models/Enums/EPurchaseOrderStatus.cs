using System.ComponentModel;

namespace Newme.Purchase.Domain.Models.Enums
{
    public enum EPurchaseOrderStatus
    {
        [Description("inicial")]
        Initial = 0,

        [Description("validação do pagamento")]
        PaymentValidation = 1,

        [Description("pagamento autorizado")]
        PaymentAuthorized = 2,

        [Description("pagamento não autorizado")]
        PaymentUnauthorized = 3,

        [Description("compra não aprovada porque o produto estava fora de estoque")]
        OutOfStock = 4,

        [Description("compra aprovada com itens faltantes")]
        PartiallyApproved = 5,

        [Description("compra aprovada")]
        Approved = 6
    }
}

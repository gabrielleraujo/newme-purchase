using Newme.Purchase.Domain.Extensions;
using Newme.Purchase.Domain.Models.Enums;

namespace Newme.Purchase.Infrastructure.Configurations.Utils
{
    public class PurchaseOrderState
    {
        private PurchaseOrderState() {}
        public PurchaseOrderState(EPurchaseOrderState state)
        {
            Id = Guid.NewGuid();
            State = state;
            Description = state.GetEnumDescription();
        }

        public Guid Id { get; set; }
        public EPurchaseOrderState State { get; private set; }
        public string Description { get; private set; }
    }
}

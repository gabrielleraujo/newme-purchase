using Newme.Purchase.Domain.Extensions;

namespace Newme.Purchase.Infrastructure.Configurations.Utils
{
    public abstract class StatusBase<T> where T : Enum
    {
        private StatusBase() {}
        public StatusBase(T status)
        {
            Id = Guid.NewGuid();
            Status = status;
            Description = status.GetEnumDescription();
        }

        public Guid Id { get; set; }
        public T Status { get; private set; }
        public string Description { get; private set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Newme.Purchase.Domain.Models.Abstracts
{
    public abstract class Entity
    {
        protected Entity()
        { }

        protected Entity(Guid id)
        {
            Id = id;
        }

        [Key]
        public Guid Id { get; private set; }
    }
}
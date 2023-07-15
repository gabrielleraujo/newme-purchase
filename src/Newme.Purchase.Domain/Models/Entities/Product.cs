using Newme.Purchase.Domain.Models.Abstracts;
using Newme.Purchase.Domain.Models.ValueObjects;

namespace Newme.Purchase.Domain.Models.Entities
{
    public class Product : Entity
    {
        private Product() { }
        public Product(
            Guid id, 
            string name, 
            double price, 
            string description, 
            Category category, 
            Color color, 
            Size size) : base(id)
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            Color = color;
            Size = size;
        }

        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }

        public Category Category { get; private set; }
        public Color Color { get; private set; }
        public Size Size { get; private set; }
    }
}
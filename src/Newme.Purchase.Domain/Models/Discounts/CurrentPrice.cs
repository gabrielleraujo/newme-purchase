namespace Newme.Purchase.Domain.Models.Discounts
{
    public class CurrentPrice
    {
        public CurrentPrice(double price)
        {
            Price = price;
        }

        public double Price { get; set; }
    }
}
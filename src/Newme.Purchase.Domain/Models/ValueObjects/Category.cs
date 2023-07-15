namespace Newme.Purchase.Domain.Models.ValueObjects
{
    public record Category
    {
        private Category() {}
        public Category(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
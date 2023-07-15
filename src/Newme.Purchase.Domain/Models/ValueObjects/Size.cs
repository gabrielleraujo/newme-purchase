namespace Newme.Purchase.Domain.Models.ValueObjects
{
    public record Size
    {
        private Size() {}
        public Size(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
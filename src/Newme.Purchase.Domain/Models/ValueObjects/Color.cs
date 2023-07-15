namespace Newme.Purchase.Domain.Models.ValueObjects
{
    public record Color
    {
        private Color() {}
        public Color(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }
    }
}
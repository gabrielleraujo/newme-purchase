using System.Text.Json.Serialization;

namespace Newmw.Purchase.Application.ViewModels
{
    public class ReadBuyerViewModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
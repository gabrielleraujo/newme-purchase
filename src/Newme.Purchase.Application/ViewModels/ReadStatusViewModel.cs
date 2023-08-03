using System.Text.Json.Serialization;

namespace Newmw.Purchase.Application.ViewModels
{
    public class ReadStatusViewModel
    {
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
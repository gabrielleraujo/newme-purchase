using System.Text.Json.Serialization;

namespace Newmw.Purchase.Application.ViewModels
{
    public class ReadAddressViewModel
    {
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("complement")]
        public string Complement { get; set; }

        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("uf")]
        public string UF { get; set; }
    }
}
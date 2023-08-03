using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class CreateAddressInputModel
    {
        [Required(ErrorMessage = "The zipcode is Required")]
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "The street is Required")]
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The number is Required")]
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [Required(ErrorMessage = "The complement is Required")]
        [JsonPropertyName("complement")]
        public string Complement { get; set; }

        [Required(ErrorMessage = "The neighborhood is Required")]
        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "The city is Required")]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "The uf is Required")]
        [JsonPropertyName("uf")]
        public string UF { get; set; }
    }
}
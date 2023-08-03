using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class CreateBuyerInputModel
    {
        [Required(ErrorMessage = "The id is Required")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name is Required")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The surname is Required")]
        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The username is Required")]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The email is Required")]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class InputProductInputModel
    {
        [Required(ErrorMessage = "The id is Required")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name is Required")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description is Required")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The category is Required")]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "The color is Required")]
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "The size is Required")]
        [JsonPropertyName("size")]
        public string Size { get; set; }
    }
}
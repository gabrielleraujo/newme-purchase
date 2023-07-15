using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class InputProductInputModel
    {
        [Required(ErrorMessage = "The id is Required")]
        [DisplayName("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name is Required")]
        [DisplayName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The price is Required")]
        [DisplayName("price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The description is Required")]
        [DisplayName("description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "The category is Required")]
        [DisplayName("category")]
        public InputCategoryInputModel Category { get; set; }

        [Required(ErrorMessage = "The color is Required")]
        [DisplayName("color")]
        public InputColorInputModel Color { get; set; }

        [Required(ErrorMessage = "The size is Required")]
        [DisplayName("size")]
        public InputSizeInputModel Size { get; set; }
    }
}
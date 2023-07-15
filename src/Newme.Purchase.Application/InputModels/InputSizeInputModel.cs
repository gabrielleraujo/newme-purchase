using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class InputSizeInputModel
    {
        [Required(ErrorMessage = "The id is Required")]
        [DisplayName("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name is Required")]
        [DisplayName("name")]
        public string Text { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class InputColorInputModel
    {
        [Required(ErrorMessage = "The id is Required")]
        [DisplayName("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name is Required")]
        [DisplayName("name")]
        public virtual string Text { get; set; }
    }
}
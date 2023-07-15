using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class CreateBuyerInputModel
    {
        [Required(ErrorMessage = "The id is Required")]
        [DisplayName("id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name is Required")]
        [DisplayName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The surname is Required")]
        [DisplayName("surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The username is Required")]
        [DisplayName("surname")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The email is Required")]
        [DisplayName("email")]
        public string Email { get; set; }
    }
}
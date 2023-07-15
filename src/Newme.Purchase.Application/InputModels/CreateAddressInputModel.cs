using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class CreateAddressInputModel
    {
        [Required(ErrorMessage = "The zipcode is Required")]
        [DisplayName("zipcode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "The street is Required")]
        [DisplayName("street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The number is Required")]
        [DisplayName("number")]
        public int Number { get; set; }

        [Required(ErrorMessage = "The complement is Required")]
        [DisplayName("complement")]
        public string Complement { get; set; }

        [Required(ErrorMessage = "The neighborhood is Required")]
        [DisplayName("neighborhood")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "The city is Required")]
        [DisplayName("city")]
        public string City { get; set; }

        [Required(ErrorMessage = "The uf is Required")]
        [DisplayName("uf")]
        public string UF { get; set; }
    }
}
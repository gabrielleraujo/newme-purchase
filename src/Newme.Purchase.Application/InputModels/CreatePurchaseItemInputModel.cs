using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;

namespace Newmw.Purchase.Application.InputModels
{
    public class CreatePurchaseItemInputModel
    {
        [Ignore]
        public Guid Id  { get; set; }

        [Ignore]
        public Guid PurchaseId { get; set; }

        [Required(ErrorMessage = "The product_id is Required")]
        [DisplayName("product_id")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "The product is Required")]
        [DisplayName("product")]
        public InputProductInputModel Product { get; set; }

        [Required(ErrorMessage = "The unit_price is Required")]
        [DisplayName("unit_price")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "The quantity is Required")]
        [DisplayName("quantity")]
        public int Quantity { get; set; }
    }
}
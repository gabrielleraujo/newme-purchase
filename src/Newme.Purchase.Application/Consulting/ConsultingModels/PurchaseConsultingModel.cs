using Newmw.Purchase.Application.InputModels;

namespace Newme.Purchase.Application.Consulting.ConsultingModels
{
    public class PurchaseConsultingModel : ConsultingModel
    {
        public BuyerConsultingModel Buyer { get; set; }
        public IList<PurchaseItemConsultingModel> PurchaseItems { get; set; }
        public AddressConsultingModel Address { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public bool HasSummary { get; set; }
        public double FreightValue { get; set; }
        public string Status { get; set; }

        public PurchaseConsultingModel AddPurchaseItemDetails(IEnumerable<InputProductInputModel> products) 
        {
            foreach (var product in products)
            {
                foreach (var item in PurchaseItems)
                {
                    if (item.ProductId == product.Id)
                    {
                        item.AddDetails(new ProductConsultingModel(
                            name: product.Name,
                            description: product.Description,
                            category: product.Category,
                            color: product.Color,
                            size: product.Size
                        ));
                    }
                }
            }

            return this;
        }

        public PurchaseConsultingModel AddBuyer(CreateBuyerInputModel buyer)
        {
            Buyer = new BuyerConsultingModel() 
            {
                Name = buyer.Name,
                Surname = buyer.Surname,
                Username = buyer.Username,
                Email = buyer.Email
            };
            
            return this;
        }
    }
}

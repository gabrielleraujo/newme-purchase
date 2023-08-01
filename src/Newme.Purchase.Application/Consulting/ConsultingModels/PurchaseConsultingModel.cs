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
    }
}
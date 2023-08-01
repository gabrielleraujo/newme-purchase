namespace Newme.Purchase.Application.Consulting.ConsultingModels
{
    public class PurchaseItemConsultingModel : ConsultingModel
    {
        public Guid PurchaseId { get; set; }
        public Guid ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
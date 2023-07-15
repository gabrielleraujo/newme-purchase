namespace Newmw.Purchase.Application.ViewModels
{
    public class ReadPurchaseItemViewModel
    {
        public Guid Id { get; set; }
        public Guid PurchaseId { get; set; }
        public Guid ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
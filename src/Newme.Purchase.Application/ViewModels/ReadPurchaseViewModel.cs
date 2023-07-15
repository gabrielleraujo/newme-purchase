namespace Newmw.Purchase.Application.ViewModels
{
    public class ReadPurchaseViewModel
	{
        public Guid Id { get; set; }
        public ReadBuyerViewModel Buyer { get; set; }
        public IList<ReadPurchaseItemViewModel> PurchaseItems { get; set; }
        public ReadAddressViewModel Address { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public bool HasSummary { get; set; }
        public double FreightValue { get; set; }
        public string Status { get; set; }
    }
}
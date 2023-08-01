namespace Newme.Purchase.Infrastructure.Consulting.Mappings
{
    public class MongoMapper
    {
        public static void Configure()
        {
            ConsultingModelMapper.Map();
            AddressConsultingModelMapper.Map();
            BuyerConsultingModelMapper.Map();
            ProductConsultingModelMapper.Map();
            PurchaseConsultingModelMapper.Map();
            PurchaseItemConsultingModelMapper.Map();
        }
    }
}
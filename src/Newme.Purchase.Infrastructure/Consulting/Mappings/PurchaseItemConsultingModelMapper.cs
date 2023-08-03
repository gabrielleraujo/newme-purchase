using MongoDB.Bson.Serialization;
using Newme.Purchase.Application.Consulting.ConsultingModels;

namespace Newme.Purchase.Infrastructure.Consulting.Mappings
{
    public class PurchaseItemConsultingModelMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(PurchaseItemConsultingModel)))
            {
                BsonClassMap.RegisterClassMap<PurchaseItemConsultingModel>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.PurchaseId).SetElementName("purchase_id");
                    classMap.MapMember(p => p.ProductId).SetElementName("product_id");
                    classMap.MapMember(p => p.Details).SetElementName("details");
                    classMap.MapMember(p => p.UnitPrice).SetElementName("unit_price");
                    classMap.MapMember(p => p.Quantity).SetElementName("quantity");
                    classMap.MapMember(p => p.Status).SetElementName("status");
                });
            }
        }
    }
}
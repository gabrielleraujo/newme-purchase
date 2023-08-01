using MongoDB.Bson.Serialization;
using Newme.Purchase.Application.Consulting.ConsultingModels;

namespace Newme.Purchase.Infrastructure.Consulting.Mappings
{
    public class PurchaseConsultingModelMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(PurchaseConsultingModel)))
            {
                BsonClassMap.RegisterClassMap<PurchaseConsultingModel>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.Buyer).SetElementName("buyer");
                    classMap.MapMember(p => p.PurchaseItems).SetElementName("purchase_items");
                    classMap.MapMember(p => p.Address).SetElementName("address");
                    classMap.MapMember(p => p.Date).SetElementName("date");
                    classMap.MapMember(p => p.Price).SetElementName("price");
                    classMap.MapMember(p => p.HasSummary).SetElementName("has_summary");
                    classMap.MapMember(p => p.FreightValue).SetElementName("freight_value");
                    classMap.MapMember(p => p.Status).SetElementName("status");
                });
            }
        }
    }
}

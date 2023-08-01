using MongoDB.Bson.Serialization;
using Newme.Purchase.Application.Consulting.ConsultingModels;

namespace Newme.Purchase.Infrastructure.Consulting.Mappings
{
    public class ProductConsultingModelMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(ProductConsultingModel)))
            {
                BsonClassMap.RegisterClassMap<ProductConsultingModel>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.Name).SetElementName("name");
                    classMap.MapMember(p => p.Price).SetElementName("price");
                    classMap.MapMember(p => p.Description).SetElementName("description");
                    classMap.MapMember(p => p.Category).SetElementName("category");
                    classMap.MapMember(p => p.Color).SetElementName("color");
                    classMap.MapMember(p => p.Size).SetElementName("size");
                });
            }
        }
    }
}

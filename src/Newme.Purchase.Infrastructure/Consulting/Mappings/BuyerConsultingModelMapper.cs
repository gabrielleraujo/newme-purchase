using MongoDB.Bson.Serialization;
using Newme.Purchase.Application.Consulting.ConsultingModels;

namespace Newme.Purchase.Infrastructure.Consulting.Mappings
{
    public class BuyerConsultingModelMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(BuyerConsultingModel)))
            {
                BsonClassMap.RegisterClassMap<BuyerConsultingModel>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.Name).SetElementName("name");
                    classMap.MapMember(p => p.Surname).SetElementName("surname");
                    classMap.MapMember(p => p.Username).SetElementName("username");
                    classMap.MapMember(p => p.Email).SetElementName("email");
                });
            }
        }
    }
}
using MongoDB.Bson.Serialization;
using Newme.Purchase.Application.Consulting.ConsultingModels;

namespace Newme.Purchase.Infrastructure.Consulting.Mappings
{
    public class AddressConsultingModelMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(AddressConsultingModel)))
            {
                BsonClassMap.RegisterClassMap<AddressConsultingModel>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.ZipCode).SetElementName("zip_code");
                    classMap.MapMember(p => p.Street).SetElementName("street");
                    classMap.MapMember(p => p.Number).SetElementName("number");
                    classMap.MapMember(p => p.Complement).SetElementName("complement");
                    classMap.MapMember(p => p.Neighborhood).SetElementName("neighborhood");
                    classMap.MapMember(p => p.City).SetElementName("city");
                    classMap.MapMember(p => p.UF).SetElementName("uf");
                });
            }
        }
    }
}
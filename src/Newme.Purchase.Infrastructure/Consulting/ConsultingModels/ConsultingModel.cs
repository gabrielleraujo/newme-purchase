using MongoDB.Bson.Serialization.Attributes;

namespace Newme.Purchase.Infrastructure.Consulting.ConsultingModels
{
    public class ConsultingModel
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
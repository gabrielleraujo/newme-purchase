using MongoDB.Bson.Serialization.Attributes;

namespace Newme.Purchase.Infrastructure.Consulting.ConsultingModels
{
    public class ProductConsultingModel 
    {
        [BsonId]
        public Guid Id { get; private set; }

        [BsonElement("name")]
        public string Name { get; private set; }

        [BsonElement("price")]
        public double Price { get; private set; }

        [BsonElement("description")]
        public string Description { get; private set; }

        [BsonElement("category")]
        public string Category { get; private set; }

        [BsonElement("color")]
        public string Color { get; private set; }

        [BsonElement("size")]
        public string Size { get; private set; }
    }
}
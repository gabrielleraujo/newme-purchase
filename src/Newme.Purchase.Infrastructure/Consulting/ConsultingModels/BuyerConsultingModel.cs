using MongoDB.Bson.Serialization.Attributes;

namespace Newme.Purchase.Infrastructure.Consulting.ConsultingModels
{
    public class BuyerConsultingModel : ConsultingModel
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }


        [BsonElement("username")]
        public string Username { get; set; }
        
        [BsonElement("email")]
        public string Email { get; set; }
    }
}
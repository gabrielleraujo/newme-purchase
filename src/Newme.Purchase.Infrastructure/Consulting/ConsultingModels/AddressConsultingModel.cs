using MongoDB.Bson.Serialization.Attributes;

namespace Newme.Purchase.Infrastructure.Consulting.ConsultingModels
{
    public class AddressConsultingModel
    {
        [BsonElement("zip_code")]
        public string ZipCode { get; set; }

        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("number")]
        public int Number { get; set; }

        [BsonElement("complement")]
        public string Complement { get; set; }

        [BsonElement("neighborhood")]
        public string Neighborhood { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("uf")]
        public string UF { get; set; }
    }
}
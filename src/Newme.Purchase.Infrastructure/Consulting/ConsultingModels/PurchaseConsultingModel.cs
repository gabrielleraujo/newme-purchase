using MongoDB.Bson.Serialization.Attributes;

namespace Newme.Purchase.Infrastructure.Consulting.ConsultingModels
{
    public class PurchaseConsultingModel : ConsultingModel
    {
        [BsonElement("buyer")]
        public BuyerConsultingModel Buyer { get; set; }

        [BsonElement("purchase_items")]
        public IEnumerable<PurchaseItemConsultingModel> PurchaseItems { get; set; }

        [BsonElement("address")]
        public AddressConsultingModel Address { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("has_summary")]
        public bool HasSummary { get; set; }

        [BsonElement("freight_value")]
        public double FreightValue { get; set; }

        [BsonElement("state")]
        public string State { get; set; }
    }
}
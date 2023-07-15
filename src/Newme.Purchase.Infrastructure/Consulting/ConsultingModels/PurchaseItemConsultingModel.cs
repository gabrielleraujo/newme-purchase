using MongoDB.Bson.Serialization.Attributes;

namespace Newme.Purchase.Infrastructure.Consulting.ConsultingModels
{
    public class PurchaseItemConsultingModel : ConsultingModel
    {
        [BsonElement("purchase_id")]
        public Guid PurchaseId { get; set; }

        [BsonElement("product_id")]
        public Guid ProductId { get; set; }

        [BsonElement("unit_price")]
        public double UnitPrice { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
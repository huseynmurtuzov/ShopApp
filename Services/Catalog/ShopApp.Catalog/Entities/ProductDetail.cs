using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ShopApp.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInformation { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}

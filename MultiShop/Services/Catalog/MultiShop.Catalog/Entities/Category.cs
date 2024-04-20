using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {

        /// <summary>
        /// Bu alanın id olduğunu söylemek için 
        /// [BsonId]
            ///[BsonRepresentation(BsonType.ObjectId)] kodlarını kullanıyoruz.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string CategoryId  { get; set; }

        public string CategoryName { get; set; }    
    }
}

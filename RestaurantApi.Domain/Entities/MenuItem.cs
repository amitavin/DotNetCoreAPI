using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantApi.Domain.Entities
{
    /// <summary>
    /// Domain entity representing a restaurant menu item.
    /// </summary>
    public class MenuItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; }
    }
}

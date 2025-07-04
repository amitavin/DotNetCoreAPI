using MongoDB.Driver;
using RestaurantApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantApi.Infrastructure.Data
{
    /// <summary>
    /// MongoContext handles MongoDB connection and collections.
    /// </summary>
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<MenuItem> MenuItems =>
            _database.GetCollection<MenuItem>("MenuItems");
    }
}

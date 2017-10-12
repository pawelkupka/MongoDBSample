using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoDBSample.Models
{
    public class CustomerRepository
    {
        private readonly IMongoDatabase _db;

        public CustomerRepository()
        {
            var client = new MongoClient();
            _db = client.GetDatabase("MongoSampleDb");
        }

        public IEnumerable<Customer> GetAll()
        {
            var filter = Builders<Customer>.Filter.Empty;
            return _db.GetCollection<Customer>("Customers").Find(filter).ToList();
        }

        public void Delete(int id)
        {
            _db.GetCollection<Customer>("Customers").FindOneAndDelete(c => c.Id == id);
        }

        public void Insert(Customer customer)
        {
            _db.GetCollection<Customer>("Customers").InsertOne(customer);
        }

        public void Update(Customer customer)
        {
            var filter = Builders<Customer>.Filter.Eq("Id", customer.Id);
            var update = Builders<Customer>.Update.Set("Name", customer.Name);
            _db.GetCollection<Customer>("Customers").UpdateOne(filter, update);
        }

        public void DeleteAll()
        {
            var filter = Builders<Customer>.Filter.Empty;
            _db.GetCollection<Customer>("Customers").DeleteMany(filter);
        }
    }
}

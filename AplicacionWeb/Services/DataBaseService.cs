using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Services
{
    public class DataBaseService
    {
        private readonly IMongoDatabase database;

        public DataBaseService(IFacturasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
        }

        public List<T> Get<T>()
            where T : IDataBaseItem
        {
            IMongoCollection<T> _collection = database.GetCollection<T>($"{typeof(T).Name}s");
            return _collection.Find(_collection => true).ToList();
        }

        public T Get<T>(string id)
            where T : IDataBaseItem
        {
            var _collection = database.GetCollection<T>($"{typeof(T).Name}s");
            return _collection.Find<T>(item => item.Id == id).FirstOrDefault();
        }

        public T Create<T>(T item)
            where T : IDataBaseItem
        {
            var _collection = database.GetCollection<T>($"{typeof(T).Name}s");
            _collection.InsertOne(item);
            return item;
        }

        public void Update<T>(string id, T itemIn)
            where T : IDataBaseItem
        {
            var _collection = database.GetCollection<T>($"{typeof(T).Name}s");
            _collection.ReplaceOne(item => item.Id == id, itemIn);
        }

        public void Remove<T>(T itemIn)
            where T : IDataBaseItem
        {
            var _collection = database.GetCollection<T>($"{typeof(T).Name} s");
            _collection.DeleteOne(item => item.Id == itemIn.Id);
        }

        public void Remove<T>(string id)
            where T : IDataBaseItem
        {
            IMongoCollection<T> _collection = database.GetCollection<T>($"{typeof(T).Name}s");
            _collection.DeleteOne(item => item.Id == id);
        }

    }
}

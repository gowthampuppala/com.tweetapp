using com.tweetapp.Dal.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;


namespace com.tweetapp.Dal.Interface
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoDbContext(IOptions<Mongosettings> configuration)
        {
            _mongoClient = new MongoClient("mongodb+srv://gowtham:12345@cluster0.kt3wy.mongodb.net/?retryWrites=true&w=majority");
            _db = _mongoClient.GetDatabase("TweetAppDB");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}

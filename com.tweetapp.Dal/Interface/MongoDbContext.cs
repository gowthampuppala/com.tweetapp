using com.tweetapp.Dal.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;


namespace com.tweetapp.Dal.Interface
{
    
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IConfiguration _config;

        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoDbContext(IConfiguration IConfig, IOptions<Mongosettings> configuration)
        {
            this._config = IConfig;
            _mongoClient = new MongoClient(_config.GetConnectionString("Connection"));
            _db = _mongoClient.GetDatabase("TweetAppDB");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}

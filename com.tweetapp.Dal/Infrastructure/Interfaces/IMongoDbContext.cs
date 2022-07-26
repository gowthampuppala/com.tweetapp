using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.tweetapp.Dal.Infrastructure.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}

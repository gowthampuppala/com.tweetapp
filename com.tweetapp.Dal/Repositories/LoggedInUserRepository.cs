using com.tweetapp.Dal.Infrastructure.Interfaces;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweetapp.Dal.Repositories
{
    public class LoggedInUserRepository : ILoggedInUserRepository
    {
        private readonly IMongoDbContext _context;
        protected IMongoCollection<Tweet> _dbCollection;

        public LoggedInUserRepository(IMongoDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<Tweet>("Tweets");
        }

        public async Task<string> AddTweet(Tweet tweet)
        {
            tweet.Likes = new List<string>() { };
            tweet.Comments = new List<string>() { "" };
            try
            {
                await _dbCollection.InsertOneAsync(tweet);
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> LikeTweet(string userID,string tweetId )
        {
            try
            {
                var tweet = await _dbCollection.Find<Tweet>(x => x.Id == tweetId).FirstOrDefaultAsync();
                if ( !(tweet.Likes is null) && tweet.Likes.Contains(userID))
                {
                    return "already liked";
                }
                else
                {
                    var filter = Builders<Tweet>.Filter.Eq(x => x.Id, tweetId);
                    var update = Builders<Tweet>.Update.AddToSet<string>("Likes", userID);
                    await _dbCollection.FindOneAndUpdateAsync<Tweet>(filter, update);
                }
                return "Success";
            }
            catch
            {
                throw;
            }
        }
    }
}

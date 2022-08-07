using com.tweetapp.Dal.Infrastructure.Interfaces;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using com.tweetapp.Domain.Output;
using System.Web.Http.Results;

namespace com.tweetapp.Dal.Repositories
{
    public class LoggedInUserRepository : ILoggedInUserRepository
    {
        private readonly IMongoDbContext _context;
        protected IMongoCollection<Tweet> _dbCollection;
        protected IMongoCollection<UserDetails> _UserCollection;

        public LoggedInUserRepository(IMongoDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<Tweet>("Tweets");
            _UserCollection = _context.GetCollection<UserDetails>("Users");
        }

        public async Task<string> AddTweet(Tweet tweet)
        {
            tweet.Likes = new List<string>() { };
            tweet.Comments = new List<string>() {  };
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

        public async Task<string> DeleteTweet(string id)
        {
            try
            {
                var tweet = await _dbCollection.DeleteOneAsync<Tweet>(x => x.Id == id);
                return "Success";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TweetDto>> GetAllTweets()
        {
            try
            {
                await Task.Delay(1);
                var tweet =  _dbCollection.AsQueryable<Tweet>(null);
                var res = tweet.ToList();
                var tweets = new List<TweetDto>();
                foreach (var item in res)
                {
                    var Tweet = new TweetDto();
                    Tweet.Id = item.Id;
                    Tweet.UserId = item.UserId;
                    Tweet.PostedOn = item.PostedOn;
                    Tweet.PostMessage = item.PostMessage;
                    Tweet.Likes = item.Likes;
                    Tweet.Comments = item.Comments;
                    var users = _UserCollection.AsQueryable<UserDetails>(null);
                    var user1 = from user in users where (user.Email == item.UserId) select user;
                    var UserDetails = user1.ToList();
                    Tweet.FirstName = UserDetails[0].FirstName;
                    Tweet.LastName = UserDetails[0].LastName;
                    tweets.Add(Tweet);
                }
                
                return tweets;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TweetDto> GetTweetById(string id)
        {
            try
            {
                await Task.Delay(1);
                var tweet = _dbCollection.AsQueryable<Tweet>(null);
                var res = from Tweeet in tweet where (Tweeet.Id == id) select Tweeet;
                var result = res.ToList();
                var Tweet = new TweetDto();
                foreach (var item in result)
                {
                    
                    Tweet.Id = item.Id;
                    Tweet.UserId = item.UserId;
                    Tweet.PostedOn = item.PostedOn;
                    Tweet.PostMessage = item.PostMessage;
                    Tweet.Likes = item.Likes;
                    Tweet.Comments = item.Comments;
                    var users = _UserCollection.AsQueryable<UserDetails>(null);
                    var user1 = from user in users where (user.Email == result[0].UserId) select user;
                    var UserDetails = user1.ToList();
                    Tweet.FirstName = UserDetails[0].FirstName;
                    Tweet.LastName = UserDetails[0].LastName;
                    
                }

                return Tweet;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TweetDto>> GetAllTweetsOfUser(string username)
        {
            try
            {
                var tweet = await _dbCollection.FindAsync<Tweet>(x => x.UserId == username);
                var res = tweet.ToList();
                var tweets = new List<TweetDto>();
                foreach (var item in res)
                {
                    var Tweet = new TweetDto();
                    Tweet.Id = item.Id;
                    Tweet.UserId = item.UserId;
                    Tweet.PostedOn = item.PostedOn;
                    Tweet.PostMessage = item.PostMessage;
                    Tweet.Likes = item.Likes;
                    Tweet.Comments = item.Comments;
                    var users = _UserCollection.AsQueryable<UserDetails>(null);
                    var user1 = from user in users where (user.Email == item.UserId) select user;
                    var UserDetails = user1.ToList();
                    Tweet.FirstName = UserDetails[0].FirstName;
                    Tweet.LastName = UserDetails[0].LastName;
                    tweets.Add(Tweet);
                }
                return tweets;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<string>> GetAllUsers()
        {
            try
            {
                await Task.Delay(1);
                var users = _UserCollection.AsQueryable<UserDetails>(null);
                var usernames = from user in users select user.FirstName;
                var userNames = usernames.ToList();
                //var res = users.ToList();
                return userNames;
            }
            catch (Exception)
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

        public async Task<string> ReplyTweet(string userID, string tweetId, string comment)
        {
            try
            {
                var tweet = await _dbCollection.Find<Tweet>(x => x.Id == tweetId).FirstOrDefaultAsync();
                var filter = Builders<Tweet>.Filter.Eq(x => x.Id, tweetId);
                var update = Builders<Tweet>.Update.AddToSet<string>("Comments", comment);
                await _dbCollection.FindOneAndUpdateAsync<Tweet>(filter, update);
                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public async Task<object> SearchByUserName(string username)
        {
            try
            {
                await Task.Delay(1);
                var users = _UserCollection.AsQueryable<UserDetails>(null);
                var user1 = from user in users where (user.Email == username )select user;
                var UserDetails = user1.ToList();
                var obj = new Dictionary<string, string>();
                obj["Firstname"] = UserDetails[0].FirstName;
                obj["Photo"] = UserDetails[0].Photo.ToString();
                obj["Email"] = UserDetails[0].Email;
                obj["Dob"] = UserDetails[0].DOB.ToString();

                return (obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateTweet(string id, string comment)
        {
            try
            {
                var tweet = await _dbCollection.Find<Tweet>(x => x.Id == id).FirstOrDefaultAsync();
                var filter = Builders<Tweet>.Filter.Eq(x => x.Id, id);
                var update = Builders<Tweet>.Update.Set<string>("PostMessage", comment);
                var updateDate = Builders<Tweet>.Update.Set<DateTime>("UpdatedOn", DateTime.Now);


                await _dbCollection.FindOneAndUpdateAsync<Tweet>(filter, update);
                return "Success";
            }
            catch
            {
                throw;
            }
        }
    }
}

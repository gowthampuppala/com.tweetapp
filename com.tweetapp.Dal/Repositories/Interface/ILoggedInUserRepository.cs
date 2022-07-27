using com.tweetapp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweetapp.Dal.Repositories.Interface
{
    public interface ILoggedInUserRepository
    {
        Task<string> AddTweet(Tweet tweet);

        Task<string> LikeTweet(string userID, string tweetId);

        Task<string> ReplyTweet(string userID, string tweetId, string comment);

        Task<string> DeleteTweet(string username, string id);

        Task<string> UpdateTweet(string username, string id, string comment);

        Task<List<Tweet>> GetAllTweetsOfUser(string username);

        Task<List<Tweet>> GetAllTweets();

        Task<List<string>> GetAllUsers();
    }
}

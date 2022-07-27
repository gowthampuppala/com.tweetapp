using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweeetapp.Service.Services.Interface
{
    public interface ILoggedInUserService
    {
        Task<string> PostTweet(PostTweet tweet);

        Task<string> LikeTweet(string userID, string tweetId);

        Task<string> ReplyTweet(string userID, string tweetId, string comment);

        Task<string> DeleteTweet(string username, string id);

        Task<string> UpdateTweet(string username, string id, string comment);

        Task<List<Tweet>> GetAllTweetsOfUser(string username);

        Task<List<Tweet>>  GetAllTweets();

        Task<List<string>> GetAllUsers();

        Task<object> SearchByUserName(string username);
    }
}

using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using com.tweetapp.Domain.Output;
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

        Task<string> DeleteTweet( string id);

        Task<string> DeleteUser(string email);

        Task<string> UpdateTweet(string id, string comment);

        Task<List<TweetDto>> GetAllTweetsOfUser(string username);

        Task<TweetDto> GetTweetById(string id);

        Task<List<TweetDto>>  GetAllTweets();

        Task<List<User>> GetAllUsers();

        Task<object> SearchByUserName(string username);
    }
}

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
    }
}

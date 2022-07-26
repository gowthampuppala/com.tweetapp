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
    }
}

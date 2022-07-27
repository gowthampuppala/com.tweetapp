using AutoMapper;
using com.tweeetapp.Service.Services.Interface;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweeetapp.Service.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IMapper mapper;
        private readonly ILoggedInUserRepository loggedInUserRepository;
        public LoggedInUserService(ILoggedInUserRepository loggedInUserRepository, IMapper mapper)
        {
            this.loggedInUserRepository = loggedInUserRepository ?? throw new System.ArgumentNullException(nameof(loggedInUserRepository));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<string> DeleteTweet(string username, string id)
        {
            try
            {
                return await loggedInUserRepository.DeleteTweet(username, id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Tweet>> GetAllTweets()
        {
            try
            {
                return await loggedInUserRepository.GetAllTweets();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Tweet>> GetAllTweetsOfUser(string username)
        {
            try
            {
                return await loggedInUserRepository.GetAllTweetsOfUser( username);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<string>> GetAllUsers()
        {
            try
            {
                return await loggedInUserRepository.GetAllUsers();
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> LikeTweet(string userID, string tweetId)
        {
            try
            {
                return await loggedInUserRepository.LikeTweet(userID, tweetId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> PostTweet(PostTweet tweet)
        {
            var newTweet = mapper.Map<Tweet>(tweet);
            try{
                return await loggedInUserRepository.AddTweet(newTweet);
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
                return await loggedInUserRepository.ReplyTweet(userID, tweetId, comment);
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
                return await loggedInUserRepository.SearchByUserName(username);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> UpdateTweet(string username, string id, string comment)
        {
            try
            {
                return await loggedInUserRepository.UpdateTweet( username, id, comment);
            }
            catch
            {
                throw;
            }
        }
    }
}

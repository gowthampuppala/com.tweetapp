using com.tweetapp.Dal.Infrastructure.Interfaces;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweetapp.Dal.Repositories
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly IMongoDbContext _context;
        protected IMongoCollection<UserDetails> _dbCollection;
        
        public UserRegistrationRepository(IMongoDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<UserDetails>("Users");
        }
        public string AddUserToDb(UserDetails userDetails)
        {
            var existingUSer = _dbCollection.Find<UserDetails>(c => c.Email == userDetails.Email ).FirstOrDefault();
            if(existingUSer is null)
            {
                _dbCollection.InsertOne(userDetails);
                return "Success";
            }
            return "User already Exists!";
        }

        public async Task<bool> IsUserAlreadyExist(string userId)
        {
            return await _dbCollection.Find(s => s.Email == userId).FirstOrDefaultAsync() != null;
        }

        public async Task<bool> updatePassword(string userId, string newPassword)
        { 
            var result = await _dbCollection.UpdateOneAsync(t => t.Email == userId, Builders<UserDetails>.Update.Set(m => m.PassWord, newPassword));
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> CheckSecurityCredential(ForgotPasswordDto credential)
        {
            var result = await _dbCollection.Find(m => m.Email == credential.EmailId &&
            m.SecurityQuestion == credential.SecurityQuestion &&
            m.Answer.ToLower() == credential.SecurityAnswer.ToLower()).FirstOrDefaultAsync();

            return result != null;
        }
    }
}
/*
 existingUSer.FirstName = "Updated";
                var filter = Builders<UserDetails>.Filter.Eq(x => x.Email, userDetails.Email);
                var update = Builders<UserDetails>.Update.Set<string>("FirstName", "Updated");
                _dbCollection.FindOneAndUpdateAsync<UserDetails>(filter, update);
*/
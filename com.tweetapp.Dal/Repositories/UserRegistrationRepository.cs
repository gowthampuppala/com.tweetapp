using com.tweetapp.Dal.Infrastructure.Interfaces;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Entities;
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
    }
}
/*
 existingUSer.FirstName = "Updated";
                var filter = Builders<UserDetails>.Filter.Eq(x => x.Email, userDetails.Email);
                var update = Builders<UserDetails>.Update.Set<string>("FirstName", "Updated");
                _dbCollection.FindOneAndUpdateAsync<UserDetails>(filter, update);
*/
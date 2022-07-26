using com.tweetapp.Dal.Infrastructure.Interfaces;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweetapp.Dal.Repositories
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly IMongoDbContext _context;
        protected IMongoCollection<UserDetails> _dbCollection;

        public UserLoginRepository(IMongoDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<UserDetails>("Users");
        }
        public async Task<string> UserLogin(LoginCreds userDetails)
        {
            var existingUser = await _dbCollection.Find<UserDetails>(c => c.Email == userDetails.UserMailId).FirstOrDefaultAsync();
            if (existingUser is null)
            {
                return "No User Found";
            }
            if(existingUser.PassWord == userDetails.Password)
            {
                return "Success";
            }
            else
            {
                return "Incorrect Password";
            }
        }
    }
}

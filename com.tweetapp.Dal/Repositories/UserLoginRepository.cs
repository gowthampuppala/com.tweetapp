using com.tweetapp.Dal.Infrastructure.Interfaces;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using com.tweetapp.Domain.Output;
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
        public async Task<User> UserLogin(LoginCreds userDetails)
        {
            var existingUser = await _dbCollection.Find<UserDetails>(c => c.Email == userDetails.UserMailId).FirstOrDefaultAsync();

            var user = new User();
            if(existingUser == null)
            {
                return null;
            }
            if(existingUser.PassWord == userDetails.Password)
            {
                user.Id = existingUser.Id;
                user.FirstName = existingUser.FirstName;
                user.LastName = existingUser.LastName;
                user.Gender = existingUser.Gender;
                user.EmailId = existingUser.Email;
                user.DateOfBirth = existingUser.DOB;
                return user;
            }
            return null;
        }
    }
}

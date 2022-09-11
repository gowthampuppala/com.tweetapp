using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweetapp.Dal.Repositories.Interface
{
    public interface IUserRegistrationRepository
    {
        string AddUserToDb(UserDetails userDetails);

        public Task<bool> IsUserAlreadyExist(string userId);

        public Task<bool> updatePassword(string userId, string newPassword);

        public Task<bool> CheckSecurityCredential(ForgotPasswordDto credential);
    }
}

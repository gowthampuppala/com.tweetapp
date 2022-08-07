using com.tweetapp.Domain.Input;
using com.tweetapp.Domain.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweetapp.Dal.Repositories.Interface
{
    public interface IUserLoginRepository
    {
        Task<User> UserLogin(LoginCreds UserCredentials);
    }
}

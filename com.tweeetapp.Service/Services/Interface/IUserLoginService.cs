using com.tweetapp.Domain.Input;
using com.tweetapp.Domain.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweeetapp.Service.Services.Interface
{
    public interface IUserLoginService
    {
        Task<User> UserLogin(LoginCreds userCredentials);
    }
}

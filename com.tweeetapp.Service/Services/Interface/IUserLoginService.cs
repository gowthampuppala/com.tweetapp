using com.tweetapp.Domain.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweeetapp.Service.Services.Interface
{
    public interface IUserLoginService
    {
        Task<string> UserLogin(LoginCreds userCredentials);
    }
}

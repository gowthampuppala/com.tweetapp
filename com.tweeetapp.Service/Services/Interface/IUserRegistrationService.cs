using com.tweetapp.Domain.Input;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweeetapp.Service.Services.Interface
{
    public interface IUserRegistrationService
    {
        string UserRegistration(UserRegistration User);
    }
}

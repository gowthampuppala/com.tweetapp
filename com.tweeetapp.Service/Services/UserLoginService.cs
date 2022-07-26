using AutoMapper;
using com.tweeetapp.Service.Services.Interface;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.tweeetapp.Service.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IMapper mapper;
        private readonly IUserLoginRepository userLoginRepository;
        public UserLoginService(IUserLoginRepository userLoginRepository, IMapper mapper)
        {
            this.userLoginRepository = userLoginRepository ?? throw new System.ArgumentNullException(nameof(userLoginRepository));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }
        public async Task<string> UserLogin(LoginCreds userCredentials)
        {
            userCredentials.Password = EncryptPassword(userCredentials.Password);
            var res = await userLoginRepository.UserLogin(userCredentials);
            return res;
        }
        private string EncryptPassword(string password)
        {
            string message = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            message = Convert.ToBase64String(encode);
            return message;
        }
    }
}

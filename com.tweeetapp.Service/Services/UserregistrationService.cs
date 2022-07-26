using AutoMapper;
using com.tweeetapp.Service.Services.Interface;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace com.tweeetapp.Service.Services
{
    public class UserregistrationService : IUserRegistrationService
    {
        private readonly IMapper mapper;
        private readonly IUserRegistrationRepository userRegistrationRepository;
        public UserregistrationService(IUserRegistrationRepository userRegistrationRepository, IMapper mapper)
        {
            this.userRegistrationRepository = userRegistrationRepository ?? throw new System.ArgumentNullException(nameof(userRegistrationRepository));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }
        public string UserRegistration(UserRegistration user)
        {
            var newUser = mapper.Map<UserDetails>(user);
            newUser.PassWord = EncryptPassword(newUser.PassWord);
            if (user.DisplayPicture is null)
            {
                return userRegistrationRepository.AddUserToDb(newUser);
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    user.DisplayPicture.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    newUser.Photo = fileBytes;
                }
            }
            return userRegistrationRepository.AddUserToDb(newUser); 
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

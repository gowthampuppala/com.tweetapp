using AutoMapper;
using com.tweeetapp.Service.Services.Interface;
using com.tweetapp.Dal.Repositories.Interface;
using com.tweetapp.Domain.Input;
using com.tweetapp.Domain.Output;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace com.tweeetapp.Service.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IMapper mapper;
        private readonly IUserLoginRepository userLoginRepository;
        public IConfiguration Configuration { get; }

        public UserLoginService(IUserLoginRepository userLoginRepository, IMapper mapper, IConfiguration configuration)
        {
            this.userLoginRepository = userLoginRepository ?? throw new System.ArgumentNullException(nameof(userLoginRepository));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            this.Configuration = configuration;
        }
        public async Task<User> UserLogin(LoginCreds userCredentials)
        {
            userCredentials.Password = EncryptPassword(userCredentials.Password);
            var res = await userLoginRepository.UserLogin(userCredentials);
            res.Token = GenerateToken(res.EmailId, res.Id, res.FirstName);
            return res;
        }
        private string GenerateToken(string email, string id, string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                //issuer: Configuration["JWT:ValidIssuer"],
                //audience: Configuration["JWT:ValidAudience"],
                claims: new[]
                {
                     new Claim(ClaimTypes.Email, email),
                     new Claim(ClaimTypes.NameIdentifier,id+""),
                     new Claim(ClaimTypes.Name,userName)
                },
                expires: DateTime.UtcNow.AddMinutes(120));
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
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

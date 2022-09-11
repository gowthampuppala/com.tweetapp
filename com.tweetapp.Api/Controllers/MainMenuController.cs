using com.tweeetapp.Service.Services.Interface;
using com.tweetapp.Domain.Input;
using com.tweetapp.Domain.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Api.Controllers
{
    [Route("api/v1.0/tweets")]
    [ApiController]
    public class MainMenuController : ControllerBase
    {
        private readonly IUserRegistrationService userRegistrationService;
        private readonly IUserLoginService userLoginService;
        public MainMenuController(IUserRegistrationService userRegistrationService, IUserLoginService userLoginService)
        {
            this.userRegistrationService = userRegistrationService;
            this.userLoginService = userLoginService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistration userDetails)
        {
            await Task.Delay(1);
            var res = userRegistrationService.UserRegistration(userDetails);
            if (res == "User already Exists!")
            {
                return StatusCode(400, new { error = $"{userDetails.Email} is already registered." });
            }
            return new JsonResult(res);
        }

        [HttpPut("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto credentials)
        {
            var isUserExist = await userRegistrationService.IsEmailIdAlreadyExist(credentials.EmailId);
            if (isUserExist != null && isUserExist == true)
            {
                var response = await userRegistrationService.ValidateSecurityCredential(credentials);
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPut("reset/{userId}")]
        public async Task<IActionResult> UpdatePassword(string userId, [FromBody] ResetPasswordDto newPassword)
        {
            var result = await userRegistrationService.ResetPassword(userId, newPassword.NewPassword);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCreds userCredentials)
        {

            var res = await userLoginService.UserLogin(userCredentials);
            if (res != null)
                return Ok(res);
            else
            {
                return StatusCode(404, new { errorMessage = "Invalid Credentials!" });
            }
        }

    }
}

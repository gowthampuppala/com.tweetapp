﻿using com.tweeetapp.Service.Services.Interface;
using com.tweetapp.Domain.Input;
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
        public IActionResult Register([FromForm] UserRegistration userDetails)
        {
            var res = userRegistrationService.UserRegistration(userDetails);
            return new JsonResult(res);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginCreds userCredentials)
        {
            var res = await userLoginService.UserLogin(userCredentials);
            return new JsonResult(res);
        }

        [HttpGet]
        [Route("{username}/forgot")]
        public IActionResult ForgotPassword(string username)
        {
            return Ok();
        }
    }
}
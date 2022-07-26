using com.tweeetapp.Service.Services.Interface;
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
    public class UserMenuController : ControllerBase
    {
        private readonly ILoggedInUserService loggedInUserService;
        public UserMenuController(ILoggedInUserService loggedInUserService)
        {
            this.loggedInUserService = loggedInUserService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult AllTweets()
        {
            return Ok();
        }

        [HttpGet]
        [Route("users/all")]
        public IActionResult GetAllUsers()
        {
            return Ok();
        }

        [HttpGet]
        [Route("user/search/{username}")]
        public IActionResult SearchByUserName()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{username}")]
        public IActionResult GetAllTweetsOfUser()
        {
            return Ok();
        }

        [HttpPost]
        [Route("{username}/add")]
        public async Task<IActionResult> PostTweet([FromForm] PostTweet tweet)
        {
            return new JsonResult(await loggedInUserService.PostTweet(tweet));
//            return Ok();
        }

        [HttpPut]
        [Route("{username}/update/{id}")]
        public IActionResult UpdateTweet()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{username}/delete/{id}")]
        public IActionResult DeleteTweet()
        {
            return Ok();
        }

        [HttpPut]
        [Route("{username}/like/{id}")]
        public async Task<IActionResult> LikeTweet(string username, string id)
        {
            return new JsonResult(await loggedInUserService.LikeTweet(username,id)); 
        }

        [HttpPost]
        [Route("{username}/reply/{id}")]
        public IActionResult ReplyToTweet()
        {
            return Ok();
        }
    }
}

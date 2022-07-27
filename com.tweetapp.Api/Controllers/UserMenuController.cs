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
        public async Task<IActionResult> UpdateTweet(string username, string id, [FromForm]string comment)
        {
            return new JsonResult(await loggedInUserService.UpdateTweet(username, id, comment));
        }

        [HttpDelete]
        [Route("{username}/delete/{id}")]
        public async Task<IActionResult> DeleteTweet(string username, string id)
        {
            return new JsonResult(await loggedInUserService.DeleteTweet(username, id));
        }

        [HttpPut]
        [Route("{username}/like/{id}")]
        public async Task<IActionResult> LikeTweet(string username, string id)
        {
            return new JsonResult(await loggedInUserService.LikeTweet(username,id)); 
        }

        [HttpPost]
        [Route("{username}/reply/{id}")]
        public async Task<IActionResult> ReplyToTweet(string username, string id, [FromForm]string comment)
        {
            return new JsonResult(await loggedInUserService.ReplyTweet(username, id, comment));
        }
    }
}

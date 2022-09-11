using com.tweeetapp.Service.Services.Interface;
using com.tweetapp.Domain.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> AllTweets()
        {
            return new JsonResult(await loggedInUserService.GetAllTweets());
        }

        [HttpGet]
        [Route("users/all")]
        public async Task<IActionResult> GetAllUsers()
        {
            return new JsonResult(await loggedInUserService.GetAllUsers());
        }

        [HttpGet]
        [Route("user/search/{username}")]
        public async Task<IActionResult> SearchByUserName(string username)
        {
            var obj = new Dictionary<string, object>();
            obj["tweets"] = await loggedInUserService.GetAllTweetsOfUser(username);
            obj["UserDetails"] = await loggedInUserService.SearchByUserName(username);
            return new JsonResult(obj);
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<IActionResult> GetAllTweetsOfUser(string username)
        {
            return new JsonResult(await loggedInUserService.GetAllTweetsOfUser(username));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostTweet([FromBody] PostTweet tweet)
        {
            return new JsonResult(await loggedInUserService.PostTweet(tweet));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetTweetById(string id)
        {
            return new JsonResult(await loggedInUserService.GetTweetById(id));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateTweet([FromBody] UpdateTweet tweet)
        {
            return new JsonResult(await loggedInUserService.UpdateTweet( tweet.Id, tweet.Tweet));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTweet(string id)
        {
            return new JsonResult(await loggedInUserService.DeleteTweet(id));
        }

        [HttpPut]
        [Route("{username}/like/{id}")]
        public async Task<IActionResult> LikeTweet(string username, string id)
        {
            return new JsonResult(await loggedInUserService.LikeTweet(username,id)); 
        }

        [HttpPost]
        [Route("{username}/reply/{id}")]
        public async Task<IActionResult> ReplyToTweet(string username, string id, [FromBody]comment comment)
        {
            return new JsonResult(await loggedInUserService.ReplyTweet(username, id, comment.commen));
        }

        [HttpDelete]
        [Route("deleteUser/{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            return new JsonResult(await loggedInUserService.DeleteUser(email));
        }
    }
}

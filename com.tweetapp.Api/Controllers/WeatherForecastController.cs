using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.tweetapp.Dal;
using com.tweetapp.Dal.Infrastructure.Interfaces;
using MongoDB.Driver;
using com.tweetapp.Domain.Output;
using com.tweetapp.Domain.Input;
using com.tweeetapp.Service.Services.Interface;

namespace com.tweetapp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMongoDbContext _context;
        protected IMongoCollection<Employee> _dbCollection;
        private readonly IUserRegistrationService userRegistrationService;
        public WeatherForecastController(IUserRegistrationService userRegistrationService,IMongoDbContext context)
        {
            this.userRegistrationService = userRegistrationService;
            _context = context;
            _dbCollection = _context.GetCollection<Employee>("Employees");
        }

        [HttpPost]
        [Route("books")]
        public IActionResult Get([FromForm] UserRegistration ur)
        {
            var res = userRegistrationService.UserRegistration(ur);
            //var all = _dbCollection.Find(FilterDefinition<Employee>.Empty).ToList().FirstOrDefault();
            return new JsonResult(res);
        }



        
    }
}

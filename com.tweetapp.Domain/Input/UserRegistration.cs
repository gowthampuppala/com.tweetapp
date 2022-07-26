using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.tweetapp.Domain.Input
{
    public class UserRegistration
    {

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PassWord { get; set; }
        
        [Required]
        public string SecurityQuestion { get; set; }
        
        [Required]
        public string Answer { get; set; }

        public IFormFile DisplayPicture { get; set; } = null;

    }
}

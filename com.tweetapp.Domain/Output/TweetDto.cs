using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.tweetapp.Domain.Output
{
    public class TweetDto
    {
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        
        public string PostMessage { get; set; }

        public List<string> Likes { get; set; }

        public List<string> Comments { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PostedOn { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.tweetapp.Domain.Input
{
    public class PostTweet
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string PostMessage { get; set; }

    }
}

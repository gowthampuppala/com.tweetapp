using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace com.tweetapp.Domain.Input
{
    public class LoginCreds
    {
        [Required]
        [EmailAddress]
        public string UserMailId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

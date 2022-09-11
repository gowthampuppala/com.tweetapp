using System;
using System.Collections.Generic;
using System.Text;

namespace com.tweetapp.Domain.Output
{
    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EmailId { get; set; }

        public byte[] Photo { get; set; }

        public string Token { get; set; }
    }
}

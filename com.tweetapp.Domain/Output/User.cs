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

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public byte[] Photo { get; set; }
    }
}

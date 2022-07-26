using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.tweetapp.Domain.Entities
{
    public class UserDetails
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }

        public string SecurityQuestion { get; set; }

        public string Answer { get; set; }

        public byte[] Photo { get; set; }
    }
}

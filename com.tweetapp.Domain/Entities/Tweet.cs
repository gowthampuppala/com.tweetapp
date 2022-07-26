using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.tweetapp.Domain.Entities
{
    public class Tweet
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string UserId { get; set; }

        public string PostMessage { get; set; }

        public List<string> Likes { get; set; } 

        public List<string> Comments { get; set; }
    }
}

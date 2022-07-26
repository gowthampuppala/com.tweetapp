using AutoMapper;
using com.tweetapp.Domain.Entities;
using com.tweetapp.Domain.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.tweeetapp.Service.Mapping
{
    public sealed class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            CreateMap<UserRegistration,UserDetails>();
            CreateMap<PostTweet,Tweet>();
        }
    }
}

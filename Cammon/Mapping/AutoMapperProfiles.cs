using AutoMapper;
using Cammon.Dto;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cammon.Mapping
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, DtoUser>().ReverseMap();
            CreateMap<Tweet, DtoTweet>().ReverseMap();
            CreateMap<Like, DtoLike>().ReverseMap();
            CreateMap<Retweet, DtoRetweet>().ReverseMap();
            CreateMap<Reply, DtoReply>().ReverseMap();
            CreateMap<Connection, DtoConnection>().ReverseMap();
        }

    }
}

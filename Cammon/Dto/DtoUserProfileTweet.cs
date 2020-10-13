using Cammon.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dto
{
    public class DtoUserProfileTweet
    {
        public DtoUser User { get; set; }
        public List<DtoTweet> dtoTweets { get; set; }
        public List<DtoConnection> takipedilen { get; set; }
        public List<DtoConnection> takipci { get; set; }
        public int TweetCount { get; set; }
    }
}

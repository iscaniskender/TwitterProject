using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dto
{
    public class DtoMainTweetsUsers
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Tweetid { get; set; }
        public string Text { get; set; }
        public DateTime Createddate { get; set; }
        public int Replyto { get; set; }


        public int LikeCount { get; set; }

        public bool likeactive { get; set; }

        public int RetweetCount { get; set; }

        public bool Retweetactive { get; set; }
        public int ReplyCount { get; set; }
    }
}

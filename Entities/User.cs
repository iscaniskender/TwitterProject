using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Entities
{
   
    public class User:BaseEntitiy
    { 
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }


        public List<Tweet> Tweets { get; set; }
        public List<Like> Likes { get; set; }
        public List<Retweet> Retweets { get; set; }
        public List<Reply> Replies { get; set; }
       
    }
}

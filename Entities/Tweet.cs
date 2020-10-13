using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Tweet:BaseEntitiy
    {
        [Key]
        public int Id { get; set; }
        public int UserId {get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime Createddate { get; set; }
        public int Replyto { get; set; }

        public List<Reply> Reply { get; set; }
        public List<Like> Likes { get; set; }
        public List<Retweet> Retweets { get; set; }
    }
}

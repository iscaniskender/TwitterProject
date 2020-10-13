using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Like:BaseEntitiy
    {
    
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }

 
        public int UserId { get; set; }
        public User User { get; set; }

   
    }

}

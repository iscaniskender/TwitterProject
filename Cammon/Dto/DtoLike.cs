using System;
using System.Collections.Generic;
using System.Text;

namespace Cammon.Dto
{
    public class DtoLike
    {
        public int TweetId { get; set; }

        public int UserId { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
    }
}

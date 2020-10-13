using System;
using System.Collections.Generic;
using System.Text;

namespace Cammon.Dto
{
    public class DtoTweet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime Createddate { get; set; }
        public int Replyto { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }

    }
}

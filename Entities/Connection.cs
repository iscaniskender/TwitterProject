using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Connection:BaseEntitiy
    {
        [ForeignKey("User")]
        public int TakipciId { get; set; }
        public User takipci { get; set; }

        [ForeignKey("User")]
        public int takipid { get; set; }
        public User takip { get; set;}

    }
}

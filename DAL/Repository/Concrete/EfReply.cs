using DAL.Context;
using DAL.Repository.Abstarct;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Concrete
{
    public class EfReply:EfRepository<Reply>,IReply
    {
        public EfReply(TwetterContext context):base(context)
        {   
                
        }

    }
}

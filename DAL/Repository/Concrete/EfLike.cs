using DAL.Context;
using DAL.Repository.Abstarct;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.Concrete
{
    public class EfLike:EfRepository<Like>,ILike
    {
        public EfLike(TwetterContext context):base(context)
        {
                
        }

        public List<Like> GetLike(int id)
        {
            using (var context = new TwetterContext())
            {
                var Likelanan = context.Likes.Where(x => x.TweetId == id).ToList();
               
                return Likelanan;
            };
        }

        public void updatestate(Like like)
        {
            using (var context = new TwetterContext())
            {
                context.Entry(like).State = EntityState.Modified;
                context.SaveChanges();
            };

        }
    }
}
